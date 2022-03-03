using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCommerce.EntityLayer.Concrete
{
    public class ProductImage
    {
        [Key]
        public int ProductImageId { get; set; }
        public string Image { get; set; }
        public bool isActive { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }


    }
}
