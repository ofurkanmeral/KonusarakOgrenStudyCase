using KonusarakOgren.Data.Abstract;
using KonusarakOgren.Data.Concrete;
using KonusarakOgren.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KonusarakOgren.Web.Controllers
{
    public class HomeController : Controller
    {
        private IExamRepository _examRepository;
        public HomeController(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }
        public async Task<IActionResult> Index()
        {
            Uri url = new Uri("https://www.wired.com/");

            HttpClient client = new HttpClient();

            string html = await client.GetStringAsync(url);

            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument(); //kütüphanemizi kullanıp htmldocument oluşturuyoruz.
            document.LoadHtml(html);//documunt değişkeninin html ine çektiğimiz htmli veriyoruz

            var basliklar = document.DocumentNode.SelectNodes("//*[@class='SummaryItemContent-gYA-Dbp bHOHql summary-item__content summary-item__content--no-rubric']//h2");
            List<string> titles = new List<string>();
            foreach (var item in basliklar)
            {
                titles.Add(item.InnerText);
            }
            ViewBag.title = titles;


            var href = document.DocumentNode.SelectNodes("//*[@class='SummaryItemContent-gYA-Dbp bHOHql summary-item__content summary-item__content--no-rubric']/a[1]");

            List<string> links = new List<string>();
            foreach (var item in href)
            {
                links.Add(item.Attributes["href"].Value);
            }
            ViewBag.link = links;



            return View();

        }

        public async Task<IActionResult> GetDescription(string val)
        {
            Uri url = new Uri("https://www.wired.com" + val);

            HttpClient client = new HttpClient();
            string html = await client.GetStringAsync(url);
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument(); //kütüphanemizi kullanıp htmldocument oluşturuyoruz.
            document.LoadHtml(html);//documunt değişkeninin html ine çektiğimiz htmli veriyoruz
            var description = document.DocumentNode.SelectNodes("//*[@class='ContentHeaderDek-uqvGp hXHCGj']").First().InnerText;
            return Json(new { description = description });
        }

        [HttpPost]
        public IActionResult SaveQuestion(Exam model)
        {
            _examRepository.Create(model);
            return Redirect("ExamList");
        }
        public IActionResult ExamList()
        {
            var exams = _examRepository.GetAll();
            return View(exams);
        }

        public IActionResult Exam(int id)
        {
            using (var context = new DataContext())
            {
                var exam = context.Exam.Include(x => x.Questions).ThenInclude(x => x.Answers).Where(x => x.ID == id).FirstOrDefault();
                return View(exam);
            }
        }
        [HttpPost]
        public IActionResult RemoveExam(int id)
        {
            var exam=_examRepository.GetById(id);
            _examRepository.Delete(exam);
            return Json("success");
        }
    }
}
