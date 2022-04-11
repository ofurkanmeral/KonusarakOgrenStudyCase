using KonusarakOgren.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgren.Data.Concrete
{
        public class GenericRepository<T, TContext> : IRepository<T>
        where T : class
        where TContext : DbContext, new()
        {

            public void Create(T entity)
            {
                using (var db = new TContext())
                {
                    db.Set<T>().Add(entity);
                    db.SaveChanges();
                }

            }

            public void Delete(T entity)
            {
                using (var context = new TContext())
                {
                    context.Set<T>().Remove(entity);
                    context.SaveChanges();
                }

            }

            public List<T> GetAll()
            {
                using (var db = new TContext())
                {
                    return db.Set<T>().ToList();

                }
            }

            public T GetById(int id)
            {
                using (var db = new TContext())
                {
                    return db.Set<T>().Find(id);
                }
            }

            public virtual void Update(T entity)
            {
                using (var context = new TContext())
                {
                    context.Entry(entity).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }
}
