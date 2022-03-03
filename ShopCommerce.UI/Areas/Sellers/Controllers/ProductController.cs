using Microsoft.AspNetCore.Mvc;
using ShopCommerce.UI.Filter;
using ShopCommerce.EntityLayer.Concrete;
using ShopCommerce.UI.Extensions;
using ShopCommerce.UI.Manager;
using ShopCommerce.BusinessLayer.Concrete;
using ShopCommerce.BusinessLayer.ValidationRules;
using FluentValidation.Results;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using ShopCommerce.DataAccessLayer.EntityFramework;

namespace ShopCommerce.UI.Areas.Sellers.Controllers
{
    [SellerFilter]
    [Area("Sellers")]
    public class ProductController : Controller
    {
        private Seller seller;
        private IWebHostEnvironment _WebHostEnvironment;
        private ProductManager productManager;
        private Seller Seller()
        {
            seller = HttpContext.Session.Get<Seller>("seller");
            return seller;
        }
        public ProductController(IWebHostEnvironment webHostEnvironment)
        {
            _WebHostEnvironment = webHostEnvironment;
            productManager = new ProductManager(new EfProductRepository());
        }

        [HttpGet]
        [Route("seller/addproduct")]
        public IActionResult AddProduct()
        {
            ViewBag.Brand = GetBrandSelectListItems();
            ViewBag.Category = GetCategorySelectListItems();
            return View();
        }

        [HttpPost]
        [Route("seller/addproduct")]
        public async Task<IActionResult> AddProduct(Product product, List<IFormFile> ProductImages)
        {

            product.CreateDate = System.DateTime.Now;
            product.isActive = true;
            product.inStock = true;
            product.SellerId = Seller().SellerId;
            product.ShopId = Seller().ShopId;
            product.Image = product.CoverPhoto.FileName;

            ProductValidator pv = new ProductValidator();
            ValidationResult results = pv.Validate(product);
            if (results.IsValid)
            {
                var CoverPhotoPath = Path.Combine(_WebHostEnvironment.WebRootPath, "ProductImages/"+product.FixedName);
                if (!Directory.Exists(CoverPhotoPath))
                {
                    Directory.CreateDirectory(CoverPhotoPath);
                }
                //file upload
                var FullCoverPhotoPath = Path.Combine(CoverPhotoPath, product.CoverPhoto.FileName);

                using (var stream = new FileStream(FullCoverPhotoPath, FileMode.Create))
                {
                    await product.CoverPhoto.CopyToAsync(stream);
                }
                productManager.Insert(product);
                ProductImageManager pim = new ManagerCreator().ProductImageManager();

                if (ProductImages != null)
                {
                    string filePath;
                    List<ProductImage> images = new List<ProductImage>();
                    foreach (var item in ProductImages)
                    {
                        filePath = Path.Combine(_WebHostEnvironment.WebRootPath, "ProductImages/" + product.FixedName);
                        if (!Directory.Exists(filePath))
                        {
                            Directory.CreateDirectory(filePath);
                        }
                        //file upload
                        var FileFullPath = Path.Combine(filePath, item.FileName);

                        using (var stream = new FileStream(FileFullPath, FileMode.Create))
                        {
                            await item.CopyToAsync(stream);
                            ProductImage pImage = new ProductImage
                            {
                                Image = item.FileName,
                                isActive = true,
                                ProductId = product.ProductId
                            };
                            images.Add(pImage);
                        }
                    }
                    pim.AddRange(images);

                }
                return Redirect("/seller");
            }
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            ViewBag.Brand = GetBrandSelectListItems();
            ViewBag.Category = GetCategorySelectListItems();
            return View(product);
        }

       [HttpGet]
       [Route("seller/EditProduct/{id}")]
        public IActionResult Edit(int id)
        {
            ViewBag.Brand = GetBrandSelectListItems();
            ViewBag.Category = GetCategorySelectListItems();

            return View(productManager.Get(id));
        }

        [HttpPost]
        [Route("seller/EditProduct")]
        public IActionResult Edit(Product product)
        {
            ViewBag.Brand = GetBrandSelectListItems();
            ViewBag.Category = GetCategorySelectListItems();
            product.UpdateDate = System.DateTime.Now;
            productManager.Update(product);
            return Redirect("/seller");
        }

        [HttpGet]
        [Route("seller/DeleteProduct/{id}")]
        public IActionResult Delete(int id)
        {
            productManager.Delete(productManager.Get(id));
            return Redirect("/seller");
        }

        private List<SelectListItem> GetBrandSelectListItems()
        {
            BrandManager bm = new ManagerCreator().BrandManager();

            List<SelectListItem> brands = (from x in bm.GetAll()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.BrandId.ToString()
                                           }
                                              ).ToList();
            return brands;
        }

        private List<SelectListItem> GetCategorySelectListItems()
        {
            CategoryManager cm = new ManagerCreator().CategoryManager();

            List<SelectListItem> cats = (from x in cm.GetAll()
                                         select new SelectListItem
                                         {
                                             Text = x.Name,
                                             Value = x.CategoryId.ToString()
                                         }
                                              ).ToList();
            return cats;
        }
    }
}
