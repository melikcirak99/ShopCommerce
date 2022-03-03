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
    public class EfShopRepository : EfGenericRepository<Shop>,IShopDal
    {
        public override IEnumerable<Shop> GetAll()
        {
            return dbset.Include(x => x.Products).Include(x=>x.Sellers).ToList();
        }

        public override IEnumerable<Shop> GetAll(Expression<Func<Shop, bool>> filter)
        {
            return dbset.Include(x => x.Products).Include(x => x.Sellers).Where(filter).ToList();
        }
    }
}
