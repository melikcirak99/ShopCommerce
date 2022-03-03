using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCommerce.EntityLayer.Concrete
{
    public class Seller
    {
        [Key]
        public int SellerId { get; set; }
        public string FullName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public int ShopId { get; set; }
        public Shop Shop { get; set; }

        public bool isActive { get; set; }
        public ICollection<Product> Products { get; set; }

        [NotMapped]
        public string ShopName { get; set; }
        //public ICollection<Order> Orders { get; set; }
        public ICollection<Ship> Ships { get; set; }

    }
}
