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
    public class EfSellerRepository : EfGenericRepository<Seller>,ISellerDal
    {
        public override Seller Get(int id)
        {
            return dbset.Where(x=>x.SellerId.Equals(id))
                .Include(x => x.Shop)
                .FirstOrDefault();
        }
        public override Seller Get(Expression<Func<Seller, bool>> filter)
        {
            return dbset.Where(filter)
                .Include(x => x.Shop)
                .FirstOrDefault();
        }
        public override IEnumerable<Seller> GetAll()
        {
            return dbset
                .Include(x => x.Shop)
                .ToList();
        }

        public override IEnumerable<Seller> GetAll(Expression<Func<Seller, bool>> filter)
        {
            return dbset
                .Include(x => x.Shop)
                .Where(filter)
                .ToList();
        }
    }
}
