using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCommerce.EntityLayer.Concrete
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreateDate { get; set; }


        [ForeignKey("OrderStatu")]
        public int OrderStatusId { get; set; }
        public OrderStatu OrderStatu { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        //public int? CargoFirmId { get; set; }
        //public CargoFirm CargoFirm { get; set; }

        public int PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }

        public int OrderIconId { get; set; }
        public OrderIcon OrderIcon { get; set; }

        [StringLength(12)]
        public string OrderNumber { get; set; }
        public int? AdressId { get; set; }
        public Adress Adress { get; set; }

        public ICollection<Product> Products { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }

        //public int SellerId { get; set; }
        //public Seller Seller { get; set; }
        public ICollection<Ship> Ships { get; set; }


    }
}
