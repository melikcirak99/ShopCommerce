using ShopCommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCommerce.DataAccessLayer.Abstract
{
    public interface IProductDal : IRepositoryDal<Product>
    {
        IEnumerable<Product> SearchByCategory(string CategoryName);
    }
}
