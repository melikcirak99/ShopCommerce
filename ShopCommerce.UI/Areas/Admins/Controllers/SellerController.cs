using Microsoft.AspNetCore.Mvc;
using ShopCommerce.BusinessLayer.Concrete;
using ShopCommerce.EntityLayer.Concrete;
using ShopCommerce.UI.Controllers;
using ShopCommerce.UI.Filter;
using ShopCommerce.UI.Functions;
using ShopCommerce.UI.Manager;
using System.Collections.Generic;
using System.Linq;

namespace ShopCommerce.UI.Areas.Admins.Controllers
{
    [Area("admins")]
    [AdminFilter]
    public class SellerController : BaseController
    {
        SellerManager sellerManager;
        public SellerController()
        {
            sellerManager = managerCreator.SellerManager();
        }

        public IActionResult Index()
        {
            var AllSellers = sellerManager.GetAll();
            return View(AllSellers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.shops = SelectListItems.ToShop();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Seller seller)
        {
            sellerManager.Insert(seller);
            return Redirect("/admins/seller");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.shops = SelectListItems.ToShop();
            var seller = sellerManager.Get(id);
            return View(seller);
        }
        [HttpPost]
        public IActionResult Edit(Seller seller)
        {
            sellerManager.Update(seller);
            return Redirect("/admins/seller");
        }
        public string SellersCount()
        {
            return sellerManager.GetAll().Count().ToString();
        }
    }
}
