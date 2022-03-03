using ShopCommerce.UI.Manager;
using Microsoft.AspNetCore.Mvc;
using ShopCommerce.BusinessLayer.Concrete;
using System.Linq;
using System.Collections.Generic;

namespace ShopCommerce.UI.ViewComponents.Category
{
    public class BrandForSearch : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            BrandManager manager = new ManagerCreator().BrandManager();
            var model = manager.GetAll(x => x.Products.Count > 0);
            return View(model);
        }
    }
}
