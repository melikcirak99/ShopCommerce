using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCommerce.EntityLayer.Concrete
{
    public class AdminStatu
    {
        [Key]
        public int AdminStatuId { get; set; }
        public string Statu { get; set; }
        public bool isActive { get; set; }
        public ICollection<Admin> Admins { get; set; }
    }
}
