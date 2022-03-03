using FluentValidation;
using ShopCommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCommerce.BusinessLayer.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.BrandId)
                .NotNull().WithMessage("Mağaza seçin");
            RuleFor(x => x.CargoPrice)
               .NotNull().WithMessage("Kargo ücreti girin");
            RuleFor(x => x.CategoryId)
               .NotNull().WithMessage("Kategori Seçin");
            RuleFor(x => x.Image)
               .NotNull().WithMessage("Kapak Fotoğrafı girin");
            RuleFor(x => x.Info)
               .NotNull().WithMessage("Ürün Bilgisi girin");
            RuleFor(x => x.Price)
               .NotNull().WithMessage("Fiyatı girin");
            RuleFor(x => x.Stock)
               .NotNull().WithMessage("Stok Adedi girin");

        }
    }
}
