using Microsoft.AspNetCore.Mvc;
using ShopCommerce.BusinessLayer.Concrete;
using ShopCommerce.EntityLayer.Concrete;
using ShopCommerce.UI.Extensions;
using ShopCommerce.UI.Filter;
using ShopCommerce.UI.Functions;
using ShopCommerce.UI.Manager;
using System.Linq;

namespace ShopCommerce.UI.Areas.Sellers.Controllers
{
    [Area("Sellers")]
    [SellerFilter]
    public class ShipController : Controller
    {
        private ShipManager shipManager;
        private Seller seller;
        private ManagerCreator managerCreator;
        private Seller Seller()
        {
            if (seller == null)
            {
                seller = HttpContext.Session.Get<Seller>("seller");
                return seller;
            }
            return seller;
        }
        public ShipController()
        {
            shipManager = new ManagerCreator().ShipManager();
            managerCreator = new ManagerCreator();
        }

        [Route("seller/orders")]
        public IActionResult Index()
        {
            var ships = shipManager.GetAll(x => x.SellerId.Equals(Seller().SellerId) && x.ShipStatuId == 1 || x.ShipStatuId == 2);
            return View(ships);
        }

        [Route("/seller/ship/edit/{id}")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.CargoFirm = SelectListItems.ToCargoFirm();
            ViewBag.ShipStatu = SelectListItems.ToShipStatus();
            var ship = shipManager.Get(id);
            return View(ship);
        }

        [Route("/seller/ship/edit")]
        [HttpPost]
        public IActionResult Edit(Ship ship)
        {
            shipManager.Update(ship);
            return Redirect("/seller/orders");
        }

        [Route("/seller/ShipCount")]
        [HttpGet]
        public string ShipCount()
        {
            return shipManager
                .GetAll(x => x.SellerId == Seller().SellerId && (x.ShipStatuId == 1 || x.ShipStatuId == 2))
                .Count()
                .ToString();
        }
        [Route("/seller/TotalShipCount")]
        [HttpGet]
        public string TotalShipCount()
        {
            return shipManager
                .GetAll(x => x.SellerId == Seller().SellerId)
                .Count()
                .ToString();
        }

        public IActionResult AllShips()
        {
            var ships = shipManager.GetAll(x => x.SellerId.Equals(Seller().SellerId));
            return View(ships);
        }

    }
}
