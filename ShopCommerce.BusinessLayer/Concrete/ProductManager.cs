using ShopCommerce.BusinessLayer.Abstract;
using ShopCommerce.DataAccessLayer.Abstract;
using ShopCommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCommerce.BusinessLayer.Concrete
{
    public class ProductManager : Manager<Product>, IProductService
    {
        IProductDal dal;
        public ProductManager(IProductDal _dal) : base(_dal)
        {
            dal = _dal;
        }

        public IEnumerable<Product> SearchByCategory(string CategoryName)
        {
            return dal.SearchByCategory(CategoryName);
        }
    }
}
