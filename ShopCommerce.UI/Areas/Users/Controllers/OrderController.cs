using Microsoft.AspNetCore.Mvc;
using ShopCommerce.EntityLayer.Concrete;
using ShopCommerce.UI.Extensions;
using ShopCommerce.UI.Filter;
using ShopCommerce.UI.Manager;
using ShopCommerce.BusinessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;

namespace ShopCommerce.UI.Areas.Users.Controllers
{
    [AllowAnonymous]
    [Area("Users")]
    [UserFilter]
    public class OrderController : Controller
    {
        private OrderManager orderManager;
        private User user;
        private ManagerCreator managerCreator;
        private new User User()
        {
            if (user == null)
            {
                user = HttpContext.Session.Get<User>("user");
                return user;
            }
            return user;
        }
        public OrderController()
        {
            managerCreator = new ManagerCreator();
            orderManager = managerCreator.OrderManager();
        }

        [Route("siparisler")]
        public IActionResult MyOrders()
        {
            var orders = orderManager.GetAll(x => x.UserId.Equals(User().UserId));
            return View(orders);
        }

    }
}
