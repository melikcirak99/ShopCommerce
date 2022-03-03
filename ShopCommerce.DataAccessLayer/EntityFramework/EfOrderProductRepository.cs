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
    public class EfOrderProductRepository : EfGenericRepository<OrderProduct>,IOrderProductDal
    {
        public override OrderProduct Get(int id)
        {
            return dbset
                .Include(x => x.Order)
                .Include(x => x.Product)
                .Include(x => x.Product.OrderProducts)
                .Include(x => x.Order.OrderProducts)
                .FirstOrDefault(x=>x.Id.Equals(id));
        }
        public override OrderProduct Get(Expression<Func<OrderProduct, bool>> filter)
        {
            return dbset
                .Include(x => x.Order)
                .Include(x => x.Product)
                .Include(x => x.Product.OrderProducts)
                .Include(x => x.Order.OrderProducts)
                .FirstOrDefault(filter);
        }
        public override IEnumerable<OrderProduct> GetAll()
        {
            return dbset
                .Include(x => x.Order)
                .Include(x => x.Product)
                .Include(x => x.Product.OrderProducts)
                .Include(x => x.Order.OrderProducts)
                .ToList();
        }
        public override IEnumerable<OrderProduct> GetAll(Expression<Func<OrderProduct, bool>> filter)
        {
            return dbset
                .Where(filter)
               .Include(x => x.Order)
               .Include(x => x.Product)
                .Include(x => x.Product.OrderProducts)
                .Include(x => x.Order.OrderProducts)
               .ToList();
        }
    }
}
