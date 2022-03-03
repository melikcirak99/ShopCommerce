using Microsoft.AspNetCore.Mvc;
using ShopCommerce.UI.Manager;
using System.Linq;

namespace ShopCommerce.UI.ViewComponents.Product
{
    public class TopSelling:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var manager = new ManagerCreator().ProductManager();
            var model = manager.GetAll(x => x.isActive == true).OrderByDescending(x => x.Stock).Take(10);
            return View(model);
        }
    }
}
