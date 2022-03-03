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
    public class EfCategoryRepository:EfGenericRepository<Category>,ICategoryDal
    {
        public override IEnumerable<Category> GetAll()
        {
            return dbset.Include(x => x.Products).ToList();
        }

        public override IEnumerable<Category> GetAll(Expression<Func<Category, bool>> filter)
        {
            return dbset.Include(x => x.Products).Where(filter).ToList();
        }
    }
}
