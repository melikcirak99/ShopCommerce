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
    public class EfCardRepository : EfGenericRepository<Card>,ICardDal
    {
        public override Card Get(int id)
        {
            return dbset.Where(x => x.CardId == id)
                .Include(x=>x.Product)
                .Include(x=>x.User)
                .FirstOrDefault();
        }
        public override Card Get(Expression<Func<Card, bool>> filter)
        {
            return dbset.Where(filter)
                .Include(x => x.Product)
                .Include(x => x.User)
                .FirstOrDefault();
        }
        public override IEnumerable<Card> GetAll()
        {
            return dbset
                .Include(x => x.Product)
                .Include(x=>x.User)
                .Include(x=>x.Product.Seller)
                .ToList();
        }

        public override IEnumerable<Card> GetAll(Expression<Func<Card, bool>> filter)
        {
            return dbset.Where(filter)
                .Include(x => x.Product)
                .Include(x => x.User)
                .Include(x => x.Product.Seller)
                .ToList();
        }
    }
}
