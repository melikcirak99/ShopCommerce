using Microsoft.AspNetCore.Mvc;
using ShopCommerce.UI.Filter;

namespace ShopCommerce.UI.Areas.Admins.Controllers
{
    [AdminFilter]
    [Area("Admins")]
    public class DefaultController : Controller
    {
        [Route("/admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
