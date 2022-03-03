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
    public class ProductImageManager : Manager<ProductImage>, IProductImageService
    {
        IProductImageDal dal;
        public ProductImageManager(IProductImageDal _dal) : base(_dal)
        {
            dal = _dal;
        }

        //public void AddRange(List<ProductImage> images)
        //{
        //    dal.AddRange(images);
        //}
    }
}
