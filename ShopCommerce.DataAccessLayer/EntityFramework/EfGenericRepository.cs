using Microsoft.EntityFrameworkCore;
using ShopCommerce.DataAccessLayer.Abstract;
using ShopCommerce.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopCommerce.DataAccessLayer.EntityFramework
{
    public class EfGenericRepository<T> : IRepositoryDal<T> where T : class
    {
        protected DbSet<T> dbset;
        protected ShopCommerceDbContext db;
        public EfGenericRepository()
        {
            db = new ShopCommerceDbContext();
            dbset = db.Set<T>();
        }

        public void AddRange(List<T> items)
        {
            dbset.AddRange(items);
            db.SaveChanges();
        }

        public void Delete(T p)
        {
            dbset.Remove(p);
            db.SaveChanges();
        }

        public virtual T Get(int id)
        {
            return dbset.Find(id);
        }

        public virtual T Get(Expression<Func<T, bool>> filter)
        {
            return dbset.Where(filter).FirstOrDefault();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return dbset.Where(filter).ToList();
        }

        public void Insert(T p)
        {
            dbset.Add(p);
            db.SaveChanges();
        }

        public void Update(T p)
        {
            dbset.Update(p);
            db.SaveChanges();
        }
    }
}
