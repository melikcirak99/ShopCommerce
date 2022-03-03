

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopCommerce.BusinessLayer.Concrete;
using ShopCommerce.DataAccessLayer.EntityFramework;
using ShopCommerce.EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using ShopCommerce.UI.Manager;
using ShopCommerce.UI.Filter;
using ShopCommerce.UI.Extensions;

namespace ShopCommerce.UI.Controllers
{
    [AllowAnonymous]
    public class CardController : Controller
    {
        CardManager cm = new CardManager(new EfCardRepository());
        private User user;
        private new User User()
        {
            user = HttpContext.Session.Get<User>("user");
            return user;
        }

        [Route("cards")]
        [HttpGet]
        public JsonResult UserCardsJson()
        {

            if (User() != null)
            {
                try
                {
                    var model = cm.GetAll(x => x.UserId == User().UserId);
                    string CardCount = model.Count().ToString();
                    decimal TotalPrice = model.Sum(x => x.Product.Price);
                    decimal TotalDiscount = model.Sum(x => x.Product.DisCount);

                    var jsondata = model.Select(x => new
                    {
                        Id = x.CardId,
                        Name = x.Product.Name,
                        Price = x.Product.Price - x.Product.DisCount,
                        Image = x.Product.PhotoSrc,
                        Quantity = x.ProductQuantity,
                        ItemsCount = CardCount,
                        TotalPrice = TotalPrice - TotalDiscount


                    });
                    return Json(JsonConvert.SerializeObject(jsondata));
                }
                catch
                {
                    return Json(null);
                }
            }
            return Json(null);
        }

        [HttpPost]
        [Route("card/add")]
        public IActionResult Add(Card card)
        {
            if (ModelState.IsValid)
            {
                ProductManager pm = new ManagerCreator().ProductManager();
                Product pr = pm.Get(card.ProductId);
                if (card.ProductQuantity <= pr.Stock)
                {
                    Card usersCard = cm.Get(x => x.UserId == card.UserId && x.Product.ProductId == card.ProductId);

                    if (usersCard != null)
                    {
                        usersCard.ProductQuantity += card.ProductQuantity;
                        cm.Update(usersCard);
                        return Ok($"ekleme tamamlandı");
                    }
                    cm.Insert(card);
                    return Ok($"ekleme tamamlandı");
                }
                return StatusCode(500, "ürün adedi stok adedinden fazla olamaz");
            }
            return BadRequest("gerekli alanları girin.");
        }

        [HttpGet]
        [Route("AddToCardSingle/{id}")]
        public IActionResult AddToCardSingle(int id)
        {
            if (User() != null)
            {
                try
                {
                    Card card = new Card()
                    {
                        ProductId = id,
                        ProductQuantity = 1,
                        UserId = User().UserId

                    };
                    cm.Insert(card);
                    return Ok($"Ekleme tamamlandı");
                }
                catch
                {
                    return BadRequest();
                }
            }
            return NotFound();
        }


        [HttpGet]
        [Route("card/delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {

                Card card = cm.Get(id);
                cm.Delete(card);
                return Ok($"ürün sepetten kaldırıldı");
            }
            catch
            {
                return BadRequest($"Bir hata oluştu");
            }

        }
    }
}
