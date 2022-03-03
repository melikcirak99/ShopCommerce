using ShopCommerce.BusinessLayer.Concrete;
using ShopCommerce.DataAccessLayer.EntityFramework;
using ShopCommerce.EntityLayer.Concrete;
using System;

namespace ShopCommerce.UI.Manager
{
    public class ManagerCreator
    {
        private AdminManager adminManager;
        private ProductManager productManager;
        private CategoryManager categoryManager;
        private UserManager userManager;
        private BrandManager brandManager;
        private CardManager cardManager;
        private OrderManager orderManager;
        private AdressManager adressManager;
        private PaymentTypeManager paymentType;
        private SellerManager sellerManager;
        private OrderProductManager orderProductManager;
        private WishManager wishManager;
        private ProductImageManager productImageManager;
        private CargoFirmManager cargoFirmManager;
        private OrderStatuManager orderStatuManager;
        private ShipManager shipManager;
        private ShipStatuManager shipStatuManager;
        private ShopManager shopManager;

        public AdminManager AdminManager()
        {
            adminManager = new AdminManager(new EfAdminRepository());
            return adminManager;
        }

        public CategoryManager CategoryManager()
        {
            categoryManager = new CategoryManager(new EfCategoryRepository());
            return categoryManager;
        }
        public ProductManager ProductManager()
        {
            productManager = new ProductManager(new EfProductRepository());
            return productManager;
        }
        public BrandManager BrandManager()
        {
            brandManager = new BrandManager(new EfBrandRepository());
            return brandManager;
        }
        public UserManager UserManager()
        {
            userManager = new UserManager(new EfUserRepository());
            return userManager;
        }
        public CardManager CardManager()
        {
            cardManager = new CardManager(new EfCardRepository());
            return cardManager;
        }
        public OrderManager OrderManager()
        {
            orderManager = new OrderManager(new EfOrderRepository());
            return orderManager;
        }
        public AdressManager AdressManager()
        {
            adressManager = new AdressManager(new EfAdressRepository());
            return adressManager;
        }
        public PaymentTypeManager PaymentType()
        {
            paymentType = new PaymentTypeManager(new EfPaymentTypeRepository());
            return paymentType;
        }
        public SellerManager SellerManager()
        {
            sellerManager = new SellerManager(new EfSellerRepository());
            return sellerManager;
        }
        public OrderProductManager OrderProductManager()
        {
            orderProductManager = new OrderProductManager(new EfOrderProductRepository());
            return orderProductManager;
        }
        public WishManager WishManager()
        {
            wishManager = new WishManager(new EfWishRepository());
            return wishManager;
        }
        public ProductImageManager ProductImageManager()
        {
            productImageManager = new ProductImageManager(new EfProductImageRepository());
            return productImageManager;
        }

        public CargoFirmManager CargoFirmManager()
        {
            cargoFirmManager = new CargoFirmManager(new EfCargoFirmRepository());
            return cargoFirmManager;
        }

        public OrderStatuManager OrderStatuManager()
        {
            orderStatuManager = new OrderStatuManager(new EfOrderStatuRepository());
            return orderStatuManager;
        }
        public ShipManager ShipManager()
        {
            shipManager = new ShipManager(new EfShipRepository());
            return shipManager;
        }
        public ShipStatuManager ShipStatuManager()
        {
            shipStatuManager = new ShipStatuManager(new EfShipStatuRepository());
            return shipStatuManager;
        }
        public ShopManager ShopManager()
        {
            shopManager = new ShopManager(new EfShopRepository());
            return shopManager;
        }
    }
}
