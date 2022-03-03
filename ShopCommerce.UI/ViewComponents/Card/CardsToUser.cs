using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopCommerce.EntityLayer.Concrete;
using ShopCommerce.UI.Manager;
using System.Linq;

namespace ShopCommerce.UI.ViewComponents.Product
{
    public class CardsToUser : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var manager = new ManagerCreator().CardManager();

            if(HttpContext.Session.GetString("user") != null)
            {
                int userId = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("user")).UserId;
                var model = manager.GetAll(x => x.UserId == userId);
                return View(model);
            }
            return View();
        }
    }
}
