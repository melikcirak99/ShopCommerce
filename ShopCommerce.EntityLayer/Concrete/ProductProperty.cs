using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCommerce.EntityLayer.Concrete
{
    public class ProductProperty
    {
        [Key]
        public int PropertyId { get; set; }        
        public string PropTitle { get; set; }
        public string PropValue { get; set; }
        public bool isActive { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
