using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCommerce.EntityLayer.Concrete
{
    public class Ship
    {
        public int ShipId { get; set; }
        public int Qty{ get; set; }
        public decimal TotalPrice { get; set; }
        public string TrackingNumver { get; set; }

        public DateTime ShipDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public int ShipStatuId { get; set; }
        public ShipStatu ShipStatu { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int? CargoFirmId { get; set; }
        public CargoFirm CargoFirm { get; set; }
        public string ShipNumber { get; set; }
        public int AdressId { get; set; }
        public Adress Adress { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int SellerId { get; set; }
        public Seller Seller { get; set; }

        [NotMapped]
        public decimal NetPrice { 
            get {
               if(Qty!=0 && TotalPrice != 0)
                {
                    return TotalPrice * Qty;
                }
                return 0;
            }
        }


    }
   
}
