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
    public class EfProductRepository : EfGenericRepository<Product>, IProductDal
    {
        public override Product Get(int id)
        {
            return dbset.Include(x => x.Cards)
                .Include(x => x.Category)
                .Include(x => x.Shop)
                .Include(x => x.Brand)
                .Include(x => x.ProductImages)
                .Include(x => x.ProductProperties)
                .Include(x => x.Seller)
                .FirstOrDefault(x=>x.ProductId.Equals(id));
        }
        public override Product Get(Expression<Func<Product, bool>> filter)
        {
            return dbset.Where(filter)
                .Include(x => x.Cards)
                .Include(x => x.Category)
                .Include(x => x.Shop)
                .Include(x => x.Brand)
                .Include(x => x.ProductImages)
                .Include(x => x.ProductProperties)
                .Include(x => x.Seller)
                .FirstOrDefault();
        }
        public override IEnumerable<Product> GetAll()
        {
            return dbset
                .Include(x => x.Cards)
                .Include(x => x.Category)
                .Include(x => x.Shop)
                .Include(x => x.Brand)
                .Include(x => x.ProductImages)
                .Include(x => x.ProductProperties)
                .Include(x => x.Seller)
                .ToList();
        }

        public override IEnumerable<Product> GetAll(Expression<Func<Product, bool>> filter)
        {
            return dbset.Where(filter)
                .Include(x => x.Cards)
                .Include(x => x.Category)
                .Include(x => x.Shop)
                .Include(x => x.Brand)
                .Include(x => x.ProductImages)
                .Include(x => x.ProductProperties)
                .Include(x => x.Seller)
                .ToList();
        }

        public IEnumerable<Product> SearchByCategory(string CategoryName)
        {
            return GetAll(x => x.isActive && x.Category.Name == CategoryName);
        }
    }
}
