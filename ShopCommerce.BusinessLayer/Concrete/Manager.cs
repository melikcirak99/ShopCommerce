using ShopCommerce.BusinessLayer.Abstract;
using ShopCommerce.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopCommerce.BusinessLayer.Concrete
{
    public class Manager<T> : IService<T> where T:class
    {
        IRepositoryDal<T> dal;

        public Manager(IRepositoryDal<T> dal)
        {
            this.dal = dal;
        }

        public void AddRange(List<T> items)
        {
            dal.AddRange(items);
        }

        public void Delete(T p)
        {
            dal.Delete(p);
        }

        public T Get(int id)
        {
            return dal.Get(id);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return dal.Get(filter);
        }

        public IEnumerable<T> GetAll()
        {
            return dal.GetAll();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return dal.GetAll(filter);
        }

        public void Insert(T p)
        {
            dal.Insert(p);
        }

        public void Update(T p)
        {
            dal.Update(p);
        }
    }
}
