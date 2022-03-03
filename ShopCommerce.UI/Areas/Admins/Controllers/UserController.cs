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
    public class UserController : BaseController
    {
        UserManager userManager;
        public UserController()
        {
            userManager = managerCreator.UserManager();
        }

        public IActionResult Index()
        {
            var AllUsers = userManager.GetAll();
            return View(AllUsers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            userManager.Insert(user);
            return Redirect("/admins/user");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = userManager.Get(id);
            return View(user);
        }
        [HttpPost]
        public IActionResult Edit(User user)
        {
            userManager.Update(user);
            return Redirect("/admins/user");
        }

        public string UsersCount()
        {
            return userManager.GetAll().Count().ToString();
        }
    }
}
