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
    public class EfWishRepository:EfGenericRepository<Wish>,IWishDal
    {
        public override IEnumerable<Wish> GetAll()
        {
            return dbset.Include(x => x.Product).Include(x => x.User).ToList();
        }

        public override IEnumerable<Wish> GetAll(Expression<Func<Wish, bool>> filter)
        {
            return dbset.Include(x => x.Product).Include(x => x.User).Where(filter).ToList();
        }
    }
}
