using ShopCommerce.UI.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopCommerce.BusinessLayer.Concrete;
using ShopCommerce.EntityLayer.Concrete;
using ShopCommerce.UI.Manager;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace ShopCommerce.UI.Functions
{
    public static class SelectListItems
    {

        public static List<SelectListItem> ToCargoFirm()
        {
            CargoFirmManager manager = new ManagerCreator().CargoFirmManager();

            List<SelectListItem> items = (from x in manager.GetAll()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.CargoFirmId.ToString()
                                           }
                                              ).ToList();
            return items;
        }
        public static List<SelectListItem> ToOrderStatus()
        {
            OrderStatuManager manager = new ManagerCreator().OrderStatuManager();

            List<SelectListItem> items = (from x in manager.GetAll()
                                          select new SelectListItem
                                          {
                                              Text = x.Status,
                                              Value = x.OrderStatuID.ToString()
                                          }
                                              ).ToList();
            return items;
        }
        public static List<SelectListItem> ToAdress(int userId)
        {
            AdressManager manager = new ManagerCreator().AdressManager();

            List<SelectListItem> items = (from x in manager.GetAll().Where(x=>x.UserId.Equals(userId))
                                          select new SelectListItem
                                          {
                                              Text = x.FullAdress,
                                              Value = x.AdressId.ToString()
                                          }
                                              ).ToList();
            return items;
        }
        public static List<SelectListItem> ToShipStatus()
        {
            ShipStatuManager manager = new ManagerCreator().ShipStatuManager();

            List<SelectListItem> items = (from x in manager.GetAll()
                                          select new SelectListItem
                                          {
                                              Text = x.Status,
                                              Value = x.ShipStatuId.ToString()
                                          }
                                              ).ToList();
            return items;
        }

        public static List<SelectListItem> ToBrand()
        {
            BrandManager manager = new ManagerCreator().BrandManager();

            List<SelectListItem> items = (from x in manager.GetAll()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.BrandId.ToString()
                                           }
                                              ).ToList();
            return items;
        }

        public static List<SelectListItem> ToSeller()
        {
            SellerManager manager = new ManagerCreator().SellerManager();

            List<SelectListItem> items = (from x in manager.GetAll()
                                          select new SelectListItem
                                          {
                                              Text = x.FullName,
                                              Value = x.SellerId.ToString()
                                          }
                                              ).ToList();
            return items;
        }
        public static List<SelectListItem> ToShop()
        {
            ShopManager manager = new ManagerCreator().ShopManager();

            List<SelectListItem> items = (from x in manager.GetAll()
                                          select new SelectListItem
                                          {
                                              Text = x.Name,
                                              Value = x.ShopId.ToString()
                                          }
                                              ).ToList();
            return items;
        }
    }
}
