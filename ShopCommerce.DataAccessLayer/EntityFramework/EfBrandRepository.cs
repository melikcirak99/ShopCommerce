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
    public class EfBrandRepository:EfGenericRepository<Brand>,IBrandDal
    {
        public override Brand Get(int id)
        {
            return dbset
               .Include(x => x.Products)
               .FirstOrDefault(x => x.BrandId.Equals(id));
        }
        public override Brand Get(Expression<Func<Brand, bool>> filter)
        {
            return dbset
              .Include(x => x.Products)
              .FirstOrDefault(filter);
        }
        public override IEnumerable<Brand> GetAll()
        {
            return dbset
                .Include(x => x.Products)
                .ToList();
        }
        public override IEnumerable<Brand> GetAll(Expression<Func<Brand, bool>> filter)
        {
            return dbset.Where(filter)
                .Include(x => x.Products)
                .ToList();
        }
    }
}
