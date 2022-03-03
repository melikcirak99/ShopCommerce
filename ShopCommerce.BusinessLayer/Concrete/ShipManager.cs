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
    public class ShipManager : Manager<Ship>, IShipService
    {
        IShipDal dal;
        public ShipManager(IShipDal _dal) : base(_dal)
        {
            dal = _dal;
        }

    }
}
