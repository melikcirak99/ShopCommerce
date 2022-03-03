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
    public class EfProductImageRepository : EfGenericRepository<ProductImage>, IProductImageDal
    {
        public override ProductImage Get(int id)
        {
            return dbset.Where(x => x.ProductId == id).Include(x => x.Product).FirstOrDefault();
        }
        public override ProductImage Get(Expression<Func<ProductImage, bool>> filter)
        {
            return dbset.Where(filter).Include(x => x.Product).FirstOrDefault();
        }
        public override IEnumerable<ProductImage> GetAll()
        {
            return dbset.Include(x => x.Product).ToList();
        }
        public override IEnumerable<ProductImage> GetAll(Expression<Func<ProductImage, bool>> filter)
        {
            return dbset.Where(filter).Include(x => x.Product).ToList();
        }

        //public void AddRange(List<ProductImage> images)
        //{
        //    dbset.AddRange(images);
        //    db.SaveChanges();
        //}
    }
}
