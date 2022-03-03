using ShopCommerce.UI.Manager;
using Microsoft.AspNetCore.Mvc;
using ShopCommerce.BusinessLayer.Concrete;
using System.Linq;
using System.Collections.Generic;

namespace ShopCommerce.UI.ViewComponents.Category
{
    public class CategoriesForSearch : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            CategoryManager manager = new ManagerCreator().CategoryManager();
            var model = manager.GetAll(x => x.IsActive == true && x.Products.Count > 0);
            return View(model);
        }
    }
}
