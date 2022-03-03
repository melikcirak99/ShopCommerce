using Microsoft.AspNetCore.Mvc;
using ShopCommerce.UI.Manager;
using System.Linq;

namespace ShopCommerce.UI.ViewComponents.Product
{
    public class ByCategory:ViewComponent
    {
        public IViewComponentResult Invoke(int CategoryId)
        {
            var manager = new ManagerCreator().ProductManager();
            var model = manager.GetAll(x => x.isActive == true && x.Category.CategoryId == CategoryId).Take(4
                );
            ViewBag.categoryName = manager.Get(x => x.isActive == true && x.CategoryId == CategoryId).Category.Name;
            return View(model);
        }
    }
}
