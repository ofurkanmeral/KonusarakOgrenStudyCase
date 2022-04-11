using KonusarakOgren.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgren.Data.Concrete
{
    public class DataContext : DbContext
    {
        public DbSet<Question> questions { get; set; }
        public DbSet<Answer> answers { get; set; }
        public DbSet<Exam> Exam { get; set; }
        public DbSet<Users> users { get; set; }
        public DataContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        {
            optionsbuilder.UseSqlServer("server=DESKTOP-39583MR\\SQLEXPRESS;Initial Catalog=konusarakOgrenDb;Integrated Security=SSPI");
        }
    }
}
