using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgren.Entity
{
    public class Answer
    {
        public int ID { get; set; }
        public string optionA { get; set; }
        public string optionB { get; set; }
        public string optionC { get; set; }
        public string optionD { get; set; }
        public string correct { get; set; }
        public int questionID { get; set; }
        public Question Question { get; set; }
    }
}
