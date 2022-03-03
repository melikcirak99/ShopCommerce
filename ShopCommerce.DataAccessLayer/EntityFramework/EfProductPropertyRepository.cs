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
    public class EfProductPropertyRepository : EfGenericRepository<ProductProperty>,IProductPropertyDal
    {
        public override ProductProperty Get(int id)
        {
            return dbset.Where(x => x.PropertyId == id).Include(x => x.Product).FirstOrDefault();
        }
        public override ProductProperty Get(Expression<Func<ProductProperty, bool>> filter)
        {
            return dbset.Where(filter).Include(x => x.Product).FirstOrDefault();
        }
        public override IEnumerable<ProductProperty> GetAll()
        {
            return dbset.Include(x => x.Product).ToList();
        }

        public override IEnumerable<ProductProperty> GetAll(Expression<Func<ProductProperty, bool>> filter)
        {
            return dbset.Include(x => x.Product).Where(filter).ToList();
        }
    }
}
