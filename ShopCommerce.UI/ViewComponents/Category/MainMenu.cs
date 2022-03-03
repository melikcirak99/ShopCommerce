using ShopCommerce.UI.Manager;
using Microsoft.AspNetCore.Mvc;
using ShopCommerce.BusinessLayer.Concrete;
using System.Linq;
using System.Collections.Generic;

namespace ShopCommerce.UI.ViewComponents.Category
{
    public class MainMenu : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            CategoryManager manager = new ManagerCreator().CategoryManager();
            var model = manager.GetAll(x => x.IsActive == true).OrderByDescending(x => x.Products.Count).Take(7);
            return View(model);
        }
    }
}
