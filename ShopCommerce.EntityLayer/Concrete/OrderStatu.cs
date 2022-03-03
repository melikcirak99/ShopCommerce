using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCommerce.EntityLayer.Concrete
{
    public class OrderStatu
    {
        [Key]
        public int OrderStatuID { get; set; }
        public string Status { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
