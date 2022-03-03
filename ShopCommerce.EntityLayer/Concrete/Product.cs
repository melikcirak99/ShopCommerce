using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopCommerce.EntityLayer.Concrete
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public decimal Price { get; set; }
        public decimal DisCount { get; set; }

        public decimal NetPrice { get { return Price - DisCount + CargoPrice; } }
        public decimal CargoPrice { get; set; }

        public bool isActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public short Stock { get; set; }
        public bool inStock { get; set; }
        public string Image { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int ShopId { get; set; }
        public Shop Shop { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public int? SellerId { get; set; }
        public Seller Seller { get; set; }


        public ICollection<Card> Cards { get; set; }
        public ICollection<ProductProperty> ProductProperties { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }
        public ICollection<Ship> Ships { get; set; }

        [NotMapped]
        public string Link
        {
            get
            {
                if (Name == null)
                {
                    return "/urun";
                }
                return "/urun/" + Name.Replace(" ", "-").Replace("/", "") + "/" + ProductId;
            }
            set { }
        }

        [NotMapped]
        public IFormFile CoverPhoto { get; set; }

        [NotMapped]
        public string PhotoSrc
        {
            get
            {
                if (Image != null)
                {
                    return "/ProductImages/" + FixedName + "/" +Image;
                }
                else
                {
                    return "ProductImages/DefaultProductImg.png";
                }

            }
        }
        [NotMapped]
        public string FixedName
        {
            get
            {
                if (Name != null)
                {
                    return Name.Replace(" ", "-").Replace("/", "-");
                }
                else
                {
                    return "noname";
                }
            }
        }
    }
}
