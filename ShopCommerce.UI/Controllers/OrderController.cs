using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ShopCommerce.BusinessLayer.Concrete;
using ShopCommerce.BusinessLayer.ValidationRules;
using ShopCommerce.DataAccessLayer.EntityFramework;
using ShopCommerce.EntityLayer.Concrete;
using ShopCommerce.UI.Extensions;
using ShopCommerce.UI.Functions;
using ShopCommerce.UI.Manager;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopCommerce.UI.Controllers
{
    [AllowAnonymous]
    public class OrderController : BaseController
    {
        //OrderManager om = new ManagerCreator().OrderManager();
        private OrderManager om;
        public OrderController()
        {
            om = managerCreator.OrderManager();
        }
        [HttpGet]
        [Route("odeme")]
        public IActionResult Index(string error = "")
        {
            if (HttpContext.Session.GetString("user") != null)
            {
                CardManager cm = managerCreator.CardManager();
                User user = HttpContext.Session.Get<User>("user");

                ViewBag.cards = cm.GetAll(x => x.UserId.Equals(user.UserId));
                ViewBag.Adresses = GetAdressesSelectListItems(user.UserId);
                ViewBag.PaymentTypes = GetPaymentTypes();
                if (error != "")
                {
                    ViewBag.error = error;
                }
                return View();
            }
            return Redirect("/user/login");
        }

        [HttpPost]
        [Route("odemeyi-tamamla")]
        public IActionResult Finish(int AdressId = 0, int PaymentTypeId = 0)
        {

            if (HttpContext.Session.GetString("user") != null)
            {
                CardManager cm = new CardManager(new EfCardRepository());
                OrderProductManager opm = managerCreator.OrderProductManager();
                ProductManager pm = managerCreator.ProductManager();
                ShipManager sm = managerCreator.ShipManager();


                User user = HttpContext.Session.Get<User>("user");
                IEnumerable<Card> cards = cm.GetAll(x => x.UserId == user.UserId);

                Order order = new Order();
                order.UserId = user.UserId;
                order.OrderStatusId = 1;
                order.PaymentTypeId = PaymentTypeId;
                order.OrderIconId = 1;
                order.TotalPrice = (decimal)cards.Sum(x => x.Product.NetPrice * x.ProductQuantity) + (decimal)cards.Sum(x => x.Product.CargoPrice);
                order.AdressId = AdressId;
                order.CreateDate = DateTime.Now;
                order.OrderNumber = StaticFunctions.CreateDayGuid();

                //creating order
                OrderValidator ov = new OrderValidator();
                ValidationResult results = ov.Validate(order);
                if (results.IsValid)
                {
                    om.Insert(order);
                    List<Ship> ships = new List<Ship>();
                    foreach(var item in cards)
                    {
                        var _ship = new Ship()
                        {
                            AdressId = AdressId,
                            OrderId = order.OrderId,
                            ProductId = item.ProductId,
                            SellerId = (int)item.Product.SellerId,
                            ShipDate = DateTime.Now,
                            ShipNumber = StaticFunctions.CreateDayGuid(),
                            ShipStatuId = 1,
                            TotalPrice = item.Product.NetPrice,
                            UserId = user.UserId,
                            Qty=item.ProductQuantity

                        };
                        ships.Add(_ship);
                    }
                    sm.AddRange(ships);
                    
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                    ViewBag.cards = cards;
                    ViewBag.Adresses = GetAdressesSelectListItems(user.UserId);
                    ViewBag.PaymentTypes = GetPaymentTypes();
                    return View("Index");
                }

                cards = cm.GetAll(x => x.UserId.Equals(user.UserId));
                //updating product quantity
                foreach (var item in cards)
                {
                    Product pr = pm.Get(x => x.ProductId.Equals(item.ProductId));
                    pr.Stock = (short)(pr.Stock - (short)item.ProductQuantity);
                    pm.Update(pr);
                }


                //creating orderproduct
                foreach (var item in cards)
                {
                    OrderProduct op = new OrderProduct
                    {
                        OrderId = order.OrderId,
                        ProductId = item.ProductId
                    };
                    opm.Insert(op);
                }

                //deleting cards
                foreach (var card in cards)
                {
                    cm.Delete(card);
                }
                return Redirect("/siparisim/" + order.OrderId);
            }
            return Redirect("/user/login");
        }


        [HttpGet]
        [Route("siparisim/{id}")]
        public IActionResult MyOrder(int id)
        {
            if (HttpContext.Session.GetString("user") != null)
            {
                var model = om.Get(id);
                ShipManager sm = new ManagerCreator().ShipManager();
                var ships= sm.GetAll(x => x.OrderId.Equals(model.OrderId));
                ViewBag.ships = ships;
                return View(model);
            }
            return Redirect("/user/login");
        }

        private List<SelectListItem> GetAdressesSelectListItems(int userId)
        {
            AdressManager adresm = new ManagerCreator().AdressManager();

            List<SelectListItem> adresses = (from x in adresm.GetAll(x => x.UserId == userId)
                                             select new SelectListItem
                                             {
                                                 Text = x.FullAdress,
                                                 Value = x.AdressId.ToString()
                                             }
                                              ).ToList();
            return adresses;
        }
        private IEnumerable<PaymentType> GetPaymentTypes()
        {
            PaymentTypeManager pm = new ManagerCreator().PaymentType();

            return pm.GetAll();
        }

























        [HttpGet]
        [Route("sipariş")]
        public IActionResult CreateOrder()
        {
            return View();
        }

        [HttpGet]
        [Route("sipariş")]
        public IActionResult CreateOrder(Order order)
        {
            OrderValidator ov = new OrderValidator();
            ValidationResult results = ov.Validate(order);
            if (results.IsValid)
            {
                om.Insert(order);
                ViewBag.mesaj = "işlem tamam";
                return View();
            }
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            ViewBag.mesaj = "hata oldu";
            return View(order);
        }
    }
}
