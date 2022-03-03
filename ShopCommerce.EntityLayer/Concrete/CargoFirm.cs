using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCommerce.EntityLayer.Concrete
{
    public class CargoFirm
    {
        [Key]
        public int CargoFirmId { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public bool isActive { get; set; }
        //public ICollection<Order> Orders { get; set; }
        public ICollection<Ship> Ships { get; set; }
    }
}
