using KonusarakOgren.Data.Abstract;
using KonusarakOgren.Data.Concrete;
using KonusarakOgren.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KonusarakOgren.Web.Controllers
{
    public class AccountController : Controller
    {
        private IUserRepository _userRepository;
        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserViewModel userViewModel)
        {
            //Service Katmanını yazmadığım için bu şekilde kullandım
            if (ModelState.IsValid)
            {
                var context = new DataContext();
                var user = context.users.Where(x => x.username == userViewModel.username && x.password == userViewModel.password).FirstOrDefault();
                if (user == null)
                {
                    ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Yanlış");
                    return View();
                }
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,userViewModel.username)
            };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return Redirect("/Home/Index");
            }

            return View(userViewModel);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Account/Login");
        }
    }
}
