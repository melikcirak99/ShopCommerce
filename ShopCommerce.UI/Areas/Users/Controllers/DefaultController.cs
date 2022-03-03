using Microsoft.AspNetCore.Mvc;
using ShopCommerce.UI.Filter;
using ShopCommerce.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using ShopCommerce.UI.Extensions;
using ShopCommerce.UI.Manager;
using ShopCommerce.BusinessLayer.Concrete;
using ShopCommerce.BusinessLayer.ValidationRules;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;

namespace ShopCommerce.UI.Areas.Users.Controllers
{
    [AllowAnonymous]
    [UserFilter]
    [Area("Users")]
    public class DefaultController : Controller
    {
        private User user;
        private new User User()
        {
            user = HttpContext.Session.Get<User>("user");
            return user;
        }

        [Route("profil")]
        public IActionResult Index()
        {
            return View(User());
        }

        [HttpGet]
        [Route("adresekle")]
        public IActionResult AddAdress()
        {
            return View();
        }

        [HttpPost]
        [Route("adresekle")]
        public IActionResult AddAdress(Adress adress)
        {
            AdressValidator av = new AdressValidator();
            ValidationResult results = av.Validate(adress);
            if (results.IsValid)
            {
                AdressManager adresManager = new ManagerCreator().AdressManager();
                adress.UserId = User().UserId;
                adresManager.Insert(adress);
                return View();
            }
            foreach(var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View(adress);
        }
    }
}
