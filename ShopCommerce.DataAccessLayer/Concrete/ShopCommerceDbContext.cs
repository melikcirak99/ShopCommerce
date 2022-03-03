using Microsoft.EntityFrameworkCore;
using ShopCommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCommerce.DataAccessLayer.Concrete
{
    public class ShopCommerceDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=DbShopCommerce;integrated security=true");
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<AdminStatu> AdminStatus { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CargoFirm> CargoFirms { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatu> OrderStatus { get; set; }
        public DbSet<OrderIcon> OrderIcons { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductProperty> ProductProperties { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Wish> Wishes { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Ship> Ships { get; set; }
        public DbSet<ShipStatu> ShipStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasOne(x => x.Adress).WithMany(x => x.Orders).HasForeignKey(x => x.AdressId);
        }
    }
}
