using Microsoft.AspNetCore.Mvc;
using ShopCommerce.BusinessLayer.Concrete;
using ShopCommerce.EntityLayer.Concrete;
using ShopCommerce.UI.Controllers;
using ShopCommerce.UI.Filter;
using ShopCommerce.UI.Functions;
using ShopCommerce.UI.Manager;
using System.Collections.Generic;

namespace ShopCommerce.UI.Areas.Admins.Controllers
{
    [Area("admins")]
    [AdminFilter]
    public class ShopController : BaseController
    {
        ShopManager shopManager;
        public ShopController()
        {
            shopManager = managerCreator.ShopManager();
        }

        public IActionResult Index()
        {
            var AllShops = shopManager.GetAll();
            return View(AllShops);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Shop shop)
        {
            shop.CreateDate = System.DateTime.Now;
            shop.isActive = true;
            //:ToDo create a new table for status
            shop.ShopStatus = "1";
            shopManager.Insert(shop);

            return Redirect("/admins/shop");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.shops = SelectListItems.ToShop();
            var shop = shopManager.Get(id);
            return View(shop);
        }
        [HttpPost]
        public IActionResult Edit(Shop shop)
        {
            shopManager.Update(shop);
            return Redirect("/admins/shop");
        }
    }
}
