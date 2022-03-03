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
    public class EfOrderRepository : EfGenericRepository<Order>, IOrderDal
    {
        public override Order Get(int id)
        {
            return dbset
                .Where(x => x.OrderId == id)
                .Include(x => x.OrderStatu)
                .Include(x => x.User)
                .Include(x => x.PaymentType)
                .Include(x => x.OrderIcon)
                .Include(x => x.Adress)
                .Include(x => x.Ships)
                .FirstOrDefault();
        }
        public override Order Get(Expression<Func<Order, bool>> filter)
        {
            return dbset
                .Where(filter)
                .Include(x => x.OrderStatu)
                .Include(x => x.User)
                .Include(x => x.PaymentType)
                .Include(x => x.OrderIcon)
                .Include(x => x.Adress)
                .Include(x => x.Ships)
                .FirstOrDefault();
        }
        public override IEnumerable<Order> GetAll()
        {
            return dbset
                .Include(x => x.OrderStatu)
                .Include(x => x.User)
                .Include(x => x.PaymentType)
                .Include(x => x.OrderIcon)
                .Include(x => x.Adress)
                .Include(x => x.Ships)
                .ToList();
        }

        public override IEnumerable<Order> GetAll(Expression<Func<Order, bool>> filter)
        {
            return dbset
                .Include(x => x.OrderStatu)
                .Include(x => x.User)
                .Include(x => x.PaymentType)
                .Include(x => x.OrderIcon)
                .Include(x => x.Adress)
                .Include(x => x.Ships)
                .Where(filter).ToList();
        }

    }
}
