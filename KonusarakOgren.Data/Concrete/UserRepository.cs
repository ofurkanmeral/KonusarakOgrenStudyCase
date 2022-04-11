using KonusarakOgren.Data.Abstract;
using KonusarakOgren.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonusarakOgren.Data.Concrete
{
    public class UserRepository:GenericRepository<Users,DataContext>,IUserRepository
    {
    }
}
