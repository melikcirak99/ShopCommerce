using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCommerce.EntityLayer.Concrete
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }

        [StringLength(10)]
        public string PhoneNumber { get; set; }

        public bool isActive { get; set; }
        public ICollection<Card> Cards { get; set; }
        public ICollection<Order> Orders { get; set; }

        public ICollection<Adress> Adresses { get; set; }
        public ICollection<Ship> Ships { get; set; }
        [NotMapped]
        public string FullName { 
            get {
              if(FirstName!=null && LastName != null)
                {
                    return FirstName + " " + LastName;
                }
                return " ";
            }
        }

    }
}
