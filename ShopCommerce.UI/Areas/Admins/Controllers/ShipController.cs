using Microsoft.AspNetCore.Mvc;
using ShopCommerce.BusinessLayer.Concrete;
using ShopCommerce.UI.Controllers;
using ShopCommerce.UI.Filter;
using System.Linq;

namespace ShopCommerce.UI.Areas.Admins.Controllers
{
    [AdminFilter]
    [Area("Admins")]
    public class ShipController : BaseController
    {
        private ShipManager shipManager;
        public ShipController()
        {
            shipManager = managerCreator.ShipManager();
        }
        public string ShipsCount()
        {
            return shipManager.GetAll().Count().ToString();
        }
        public string TotalPrice()
        {
            return shipManager.GetAll().Sum(x=>x.NetPrice).ToString();
        }
        
    }
}
