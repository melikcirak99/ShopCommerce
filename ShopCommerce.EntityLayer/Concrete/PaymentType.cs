using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCommerce.EntityLayer.Concrete
{
    public class PaymentType
    {
        [Key]
        public int PaymentTypeId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public bool isActive { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
