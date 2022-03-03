using Microsoft.EntityFrameworkCore;
using ShopCommerce.DataAccessLayer.Abstract;
using ShopCommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopCommerce.DataAccessLayer.EntityFramework
{
    public class EfUserRepository:EfGenericRepository<User>,IUserDal
    {
        public override User Get(int id)
        {
            return dbset.Where(x=>x.UserId==id)
                .Include(x => x.Cards)
                .Include(x => x.Orders)
                .FirstOrDefault();
        }
        public override User Get(Expression<Func<User, bool>> filter)
        {
            return dbset.Where(filter)
                .Include(x => x.Cards)
                .Include(x => x.Orders)
                .FirstOrDefault();

        }
        public override IEnumerable<User> GetAll()
        {
            return dbset.Include(x => x.Cards).Include(x => x.Orders).ToList();
        }

        public override IEnumerable<User> GetAll(Expression<Func<User, bool>> filter)
        {
            return dbset.Include(x => x.Cards).Include(x => x.Orders).Where(filter).ToList();
        }
    }
}
