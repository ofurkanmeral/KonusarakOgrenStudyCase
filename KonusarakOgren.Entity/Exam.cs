using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgren.Entity
{
    public class Exam
    {
        public int ID { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; } = DateTime.Now;
        public List<Question> Questions { get; set; }
    }
}
