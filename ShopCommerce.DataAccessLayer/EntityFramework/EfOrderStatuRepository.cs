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
    public class EfOrderStatuRepository : EfGenericRepository<OrderStatu>,IOrderStatuDal
    {
        public override IEnumerable<OrderStatu> GetAll()
        {
            return dbset.Include(x => x.Orders).ToList();
        }

        public override IEnumerable<OrderStatu> GetAll(Expression<Func<OrderStatu, bool>> filter)
        {
            return dbset.Include(x => x.Orders).Where(filter).ToList();
        }
    }
}
