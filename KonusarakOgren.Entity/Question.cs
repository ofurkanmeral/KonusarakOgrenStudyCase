using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgren.Entity
{
    public class Question
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual List<Answer> Answers { get; set; }
        public int ExamID { get; set; }
        public Exam Exam { get; set; }
    }
}
