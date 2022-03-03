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
    public class OrderProductManager : Manager<OrderProduct>, IOrderProductDal
    {
        IOrderProductDal dal;
        public OrderProductManager(IOrderProductDal _dal) : base(_dal)
        {
            dal = _dal;
        }

    }
}
