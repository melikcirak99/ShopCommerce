using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopCommerce.BusinessLayer.Concrete;
using ShopCommerce.BusinessLayer.ValidationRules;
using ShopCommerce.EntityLayer.Concrete;
using ShopCommerce.DataAccessLayer.EntityFramework;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;
using ShopCommerce.UI.Extensions;
using ShopCommerce.UI.Manager;

namespace ShopCommerce.UI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        SellerManager sellerManager;
        AdminManager adminManager;
        ManagerCreator managerCreator;
        public LoginController()
        {
            managerCreator = new ManagerCreator();
            sellerManager = managerCreator.SellerManager();
            adminManager = managerCreator.AdminManager();
        }

        [HttpGet]
        public IActionResult SellerLogin()
        {
            if (HttpContext.Session.GetString("seller") != null)
            {
                return Redirect("/seller");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SellerLogin(Seller _seller)
        {
            var seller = sellerManager.Get(x => x.Mail.Equals(_seller.Mail) && x.Password.Equals(_seller.Password));

            if (seller == null)
            {
                ViewBag.message = "kullanıcı adı veya şifre hatalı";
                return View(_seller);
            }
            if (seller.isActive == false)
            {
                ViewBag.message = "Üyeliğiniz henüz onaylanmadı.";
                return View(_seller);
            }
            seller.Shop = null;
            HttpContext.Session.Set<Seller>("seller", seller);

            var claims = new List<Claim>
             {
                new Claim(ClaimTypes.Name,seller.Mail)
             };
            var sellerIdentity = new ClaimsIdentity(claims, "a");
            ClaimsPrincipal principal = new ClaimsPrincipal(sellerIdentity);
            await HttpContext.SignInAsync(principal);

            return Redirect("/seller");

        }

        //admin
        [HttpGet]
        public IActionResult AdminLogin()
        {
            if (HttpContext.Session.GetString("admin") != null)
            {
                return Redirect("/admin");
            }
            return View();
        }

        [HttpPost]
        [Route("login/adminlogin")]
        public async Task<IActionResult> AdminLogin(Admin _admin)
        {
            var admin = adminManager.Get(x => x.Mail.Equals(_admin.Mail) && x.Password.Equals(_admin.Password));

            if (admin == null)
            {
                ViewBag.message = "kullanıcı adı veya şifre hatalı";
                return View(admin);
            }

            HttpContext.Session.Set<Admin>("admin", admin);

            var claims = new List<Claim>
             {
                new Claim(ClaimTypes.Name,admin.Mail)
             };
            var adminIdentity = new ClaimsIdentity(claims, "a");
            ClaimsPrincipal principal = new ClaimsPrincipal(adminIdentity);
            await HttpContext.SignInAsync(principal);

            return Redirect("/admin");

        }
        //end of admin



        [Route("logout")]
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
