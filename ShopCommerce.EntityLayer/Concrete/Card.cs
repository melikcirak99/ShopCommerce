using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCommerce.EntityLayer.Concrete
{
    public class Card
    {
        [Key]
        public int CardId { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ProductQuantity { get; set; }


    }
}
