using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopCommerce.EntityLayer.Concrete;
using ShopCommerce.UI.Manager;
using System.Linq;

namespace ShopCommerce.UI.ViewComponents.Product
{
    public class CardsCount : ViewComponent
    {
        public string Invoke()
        {
            var manager = new ManagerCreator().CardManager();

            if(HttpContext.Session.GetString("user") != null)
            {
                return manager.GetAll().Count().ToString();
            }
            return "0";
        }
    }
}
