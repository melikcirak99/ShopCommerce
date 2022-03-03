using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopCommerce.BusinessLayer.Concrete;
using ShopCommerce.EntityLayer.Concrete;
using ShopCommerce.UI.Manager;
using Newtonsoft.Json;
using ShopCommerce.BusinessLayer.ValidationRules;
using FluentValidation.Results;

namespace ShopCommerce.UI.Areas.Users.Controllers
{
    [Area("Users")]
    [AllowAnonymous]
    public class LoginController : Controller
    {
        UserManager um = new ManagerCreator().UserManager();

        [HttpGet]
        [Route("user/login")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("user/login")]
        public IActionResult Index(ShopCommerce.EntityLayer.Concrete.User user)
        {
            if (ModelState.IsValid)
            {
                var model = um.Get(x => x.Mail == user.Mail && x.Password == user.Password);
                if (model != null)
                {
                    model.Cards = null;//this for solve ''' Self referencing loop detected ''' error
                    model.Orders = null;//this for solve ''' Self referencing loop detected ''' error

                    string _user = JsonConvert.SerializeObject(model);
                    HttpContext.Session.SetString("user", _user);
                    return Redirect("/");
                }
            }
            else
            {
                ViewBag.mesaj = "tekrar dene";
                return View(user);
            }
            ViewBag.mesaj = "bir hata oldu";
            return View(user);
        }

        //register
        [HttpGet]
        [Route("user/register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("user/register")]
        public IActionResult Register(ShopCommerce.EntityLayer.Concrete.User user)
        {
            UserValidator uv = new UserValidator();
            ValidationResult results = uv.Validate(user);
            if (results.IsValid)
            {
                var query = um.Get(x => x.Mail == user.Mail);
                if(query != null)
                {
                    ViewBag.error = "Bu mail adresi zaten kullanılıyor. Başka bir tane dene";
                    return View(user);
                }
                else
                {
                    user.isActive = true;
                    um.Insert(user);
                    return Redirect("/user/login");
                }
            }
            else
            {
                foreach(var error in results.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

            }
            return View(user);
        }
    }
}
