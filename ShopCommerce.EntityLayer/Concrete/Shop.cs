using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCommerce.EntityLayer.Concrete
{
    public class Shop
    {
        [Key]
        public int ShopId { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public bool isActive { get; set; }
        public string ShopStatus { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Seller> Sellers { get; set; }

    }
}
