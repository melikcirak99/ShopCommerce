using Microsoft.AspNetCore.Mvc;
using ShopCommerce.UI.Manager;

namespace ShopCommerce.UI.Controllers
{
    public class BaseController : Controller
    {
        protected ManagerCreator managerCreator;
        public BaseController()
        {
            managerCreator = new ManagerCreator();
        }
    }
}
