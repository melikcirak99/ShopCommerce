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
    public class SellerManager : Manager<Seller>, ISellerService
    {
        ISellerDal dal;
        public SellerManager(ISellerDal _dal) : base(_dal)
        {
            dal = _dal;
        }

    }
}
