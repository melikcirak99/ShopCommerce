using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCommerce.EntityLayer.Concrete
{
    public class ShipStatu
    {
        public int ShipStatuId { get; set; }
        public string Status { get; set; }
        public ICollection<Ship> Ships { get; set; }

    }
}
