using ShopCommerce.BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using ShopCommerce.UI.Filter;
using ShopCommerce.UI.Manager;
using System.Linq;
using Newtonsoft.Json;
using ShopCommerce.UI.Extensions;
using ShopCommerce.EntityLayer.Concrete;

namespace ShopCommerce.UI.Areas.Sellers.Controllers
{
    [Area("Sellers")]
    [SellerFilter]
    public class SellerController : Controller
    {
        SellerManager sm = new ManagerCreator().SellerManager();
        private Seller seller;
        private Seller Seller()
        {
            seller = HttpContext.Session.Get<Seller>("seller");
            return seller;
        }

        [Route("seller")]
        public IActionResult Index()
        {
            if (seller != null)
            {
                ViewBag.seller = Seller();
            }
            ProductManager pm = new ManagerCreator().ProductManager();
            ViewBag.Products = pm.GetAll(x => x.SellerId.Equals(Seller().SellerId));
            return View();
        }

        [HttpGet]
        [Route("seller/totalprice")]
        public IActionResult TotalPrice()
        {
            try
            {
                ShipManager sm = new ManagerCreator().ShipManager();
                decimal model = sm.GetAll(x => x.ShipStatuId == 3 && x.SellerId.Equals(Seller().SellerId)).Sum(x => x.NetPrice);
                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("seller/productcount")]
        public IActionResult ProductCount()
        {
            try
            {
                ProductManager pm = new ManagerCreator().ProductManager();
                int model = pm.GetAll(x => x.SellerId.Equals(Seller().SellerId)).Count();
                return Ok(model);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("seller/getsellerinfo")]
        public IActionResult GetSellerInfo()
        {
            try
            {
                return Ok(JsonConvert.SerializeObject(Seller()));
            }
            catch
            {
                return BadRequest();
            }


        }

        //account / settings
        [HttpGet]
        [Route("seller/account")]
        public IActionResult Account()
        {
            var seller = Seller();
            return View(seller);
        }

        //account / settings
        [HttpPost]
        [Route("seller/account")]
        public IActionResult Account(Seller seller)
        {
            sm.Update(seller);
            return View(seller);
        }

        [HttpGet]
        [Route("SellersShop")]
        public string SellersShop()
        {
            string ShopName = sm.Get(Seller().SellerId).Shop.Name;
            return ShopName;
        }


    }
}
