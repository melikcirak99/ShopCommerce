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
using ShopCommerce.UI.Manager;
using ShopCommerce.UI.Extensions;

namespace ShopCommerce.UI.Controllers
{
    [AllowAnonymous]
    public class ProductController : Controller
    {
        ProductManager pm = new ProductManager(new EfProductRepository());
        public IActionResult Index()
        {
            return View(pm.GetAll(x => x.isActive == true));
        }

        [Route("magazada-ara")]
        public IActionResult SearchInStore()
        {
            return View();
        }


        [Route("magazada-ara/{CategoryName}")]
        [HttpGet]
        public JsonResult SerachByCategory(string CategoryName)
        {
            try
            {
                var model = pm.SearchByCategory(CategoryName);

                var jsondata = model.Select(x => new
                {
                    Id = x.ProductId,
                    Name = x.Name,
                    Price = Convert.ToString(x.Price - x.DisCount),
                    DisCount = x.DisCount.ToString(),
                    OldPrice = x.Price.ToString(),
                    CreateDate = x.CreateDate,
                    UpdateDate = x.UpdateDate,
                    CategoryName = x.Category.Name,
                    BrandName=x.Brand.Name,
                    Image = x.PhotoSrc

                });

                return Json(JsonConvert.SerializeObject(jsondata));
            }
            catch (Exception e)
            {
                ViewBag.error = e.Message;
                return Json(null);
            }
        }

        public JsonResult Search(string CategoryName, string BrandName, string PriceMax, string PriceMin)
        {
            IEnumerable<Product> model;
            if (CategoryName != null && BrandName != null && PriceMax != null && PriceMin != null)
            {
                model = pm.GetAll(x => x.Category.Name == CategoryName && x.Brand.Name == BrandName && x.Price > Convert.ToInt32(PriceMin) && (x.Price - x.DisCount) < Convert.ToInt32(PriceMax));
            }
            else if (CategoryName != null && BrandName != null && PriceMax != null)
            {
                model = pm.GetAll(x => x.Category.Name == CategoryName && x.Brand.Name == BrandName && (x.Price - x.DisCount) < Convert.ToInt32(PriceMax));
            }
            else if (CategoryName != null && BrandName != null)
            {
                model = pm.GetAll(x => x.Category.Name == CategoryName && x.Brand.Name == BrandName);
            }
            else if (CategoryName != null && PriceMax != null)
            {
                model = pm.GetAll(x => x.Category.Name == CategoryName && (x.Price - x.DisCount) < Convert.ToInt32(PriceMax));
            }
            else if (BrandName != null && PriceMax != null)
            {
                model = pm.GetAll(x => x.Brand.Name == BrandName && (x.Price - x.DisCount) < Convert.ToInt32(PriceMax));
            }
            else if (BrandName != null)
            {
                model = pm.GetAll(x => x.Brand.Name == BrandName);
            }
            else if (CategoryName != null)
            {
                model = pm.GetAll(x => x.Category.Name == CategoryName);
            }
            else
            {
                model = pm.GetAll();
            }
            var jsondata = model.Select(x => new
            {
                Id = x.ProductId,
                Name = x.Name,
                FixedName=x.FixedName,
                Price = Convert.ToString(x.Price - x.DisCount),
                DisCount = x.DisCount.ToString(),
                OldPrice = x.Price.ToString(),
                CreateDate = x.CreateDate,
                UpdateDate = x.UpdateDate,
                CategoryName = x.Category.Name,
                BrandName = x.Brand.Name,
                Image = x.PhotoSrc

            });

            return Json(JsonConvert.SerializeObject(jsondata));
        }

        [HttpGet]
        [Route("urun/{productName}/{id}")]
        public IActionResult ProductPage(int id)
        {
            var model = pm.Get(x => x.isActive == true && x.ProductId == id);
            
            if(HttpContext.Session.GetString("user") != null)
            {
                var user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("user"));
                ViewBag.userId = user.UserId;
            }
            return View(model);
        }


        [HttpGet]
        [Route("kategori/{category}/{id}")]
        public IActionResult ByCategory(int id)
        {
            var model = pm.GetAll(x => x.isActive == true && x.CategoryId == id);
            return View(model);
        }

        [HttpGet]
        [Route("addtowish/{id}")]
        public IActionResult AddToWish(int id)
        {
            try
            {
                var wm = new ManagerCreator().WishManager();
                var model = wm.Get(x => x.ProductId.Equals(id));
                if (model == null)
                {
                    Wish wish = new Wish
                    {
                        ProductId = id,
                        UserId = HttpContext.Session.Get<User>("user").UserId
                    };
                    wm.Insert(wish);
                    return Ok("Ekleme başarılı");
                }
                return StatusCode(400, "Ürün zaten listede");

               
            }
            catch
            {
                return StatusCode(404, "eklenemedi! giriş yapmayı deneyin");
                
            }
        }

        [HttpGet]
        [Route("deletefromwish/{id}")]
        public IActionResult DeleteFromWish(int id)
        {
            try
            {
                var wm = new ManagerCreator().WishManager();
                var wish = wm.Get(x => x.ProductId == id);
                wm.Delete(wish);
                return Ok("Ürün Listeden Kaldırıldı");
            }
            catch
            {
                return BadRequest();
            }
        }
        
        [HttpGet]
        [Route("wishcount")]
        public IActionResult WishCount()
        {
            try
            {
                User user = HttpContext.Session.Get<User>("user");
                var wm = new ManagerCreator().WishManager();
                string count = wm.GetAll(x => x.UserId.Equals(user.UserId)).Count().ToString();
                return Ok(count);   
            }
            catch
            {
                return BadRequest();
            }

        }
    }
}
