using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopCommerce.BusinessLayer.Concrete;
using ShopCommerce.DataAccessLayer.EntityFramework;
using ShopCommerce.EntityLayer.Concrete;
using System;

namespace ShopCommerce.UI.Controllers
{
    [AllowAnonymous]
    public class SellerController : Controller
    {
        SellerManager sellerManager = new SellerManager(new EfSellerRepository());
        ShopManager shopManager = new ShopManager(new EfShopRepository());

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Register(Seller seller)
        {
            if (ModelState.IsValid)
            {
                var _seller = sellerManager.Get(x => x.Mail.Equals(seller.Mail));
                if (_seller != null)
                {
                    ViewBag.error = "Mail daha önceden kayıt edilmiş. başka bir tane deneyin";
                    return View(seller);
                }

                Shop shop = new()
                {
                    CreateDate = DateTime.Now,
                    isActive = false,
                    Name = seller.ShopName,

                };

                var searchedShop = shopManager.Get(x => x.Name.Equals(seller.ShopName));
                if (searchedShop != null)
                {
                    ViewBag.error = "Mağaza adı zaten kullanımda, başka bir tane deneyin";
                    return View(seller);
                }

                shopManager.Insert(shop);

                seller.ShopId = shop.ShopId;
                seller.isActive = false;
                sellerManager.Insert(seller);
                ViewBag.message = "Üyeliğiniz başarı ile oluşturuldu. Üyeliğiniz onaylanınca hesabınıza giriş yapabilirsiniz.";
                return View();

            }

            return View();
        }

    }
}
