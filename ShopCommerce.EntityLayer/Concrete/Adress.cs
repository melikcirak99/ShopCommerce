using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCommerce.EntityLayer.Concrete
{
    public class Adress
    {
        [Key]
        public int AdressId { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Neighborhood { get; set; }
        public string Street { get; set; }

        public string DoorNumber { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public ICollection<Order> Orders { get; set; }
        [NotMapped]
        public string FullAdress { get {
            return Neighborhood+" mah. "+Street+" sok. "+DoorNumber+" numara "+District+"/" + City;
            } }
        public ICollection<Ship> Ships { get; set; }




    }
}
