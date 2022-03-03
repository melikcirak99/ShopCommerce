using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopCommerce.BusinessLayer.Concrete;
using ShopCommerce.DataAccessLayer.EntityFramework;

namespace ShopCommerce.UI.Controllers
{
    [AllowAnonymous]
    public class ShipController : Controller
    {
        private ShipManager shipManager;
        public ShipController()
        {
            shipManager = new ShipManager(new EfShipRepository());
        }
        [Route("ship/cancel/{id}")]
        public IActionResult Cancel(int id)
        {
            var ship = shipManager.Get(id);
            ship.ShipStatuId = 5;
            shipManager.Update(ship);
            return Redirect("/siparisler");
        }
    }
}
