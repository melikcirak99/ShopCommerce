using FluentValidation;
using ShopCommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCommerce.BusinessLayer.ValidationRules
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(x => x.AdressId)
                .NotNull().WithMessage("Adres seçin.. Sistemde kayıtlı adresiniz yoksa profilim sayfasından ekleyiniz.")
                .GreaterThanOrEqualTo(1).WithMessage("Adres seçin.. Sistemde kayıtlı adresiniz yoksa profilim sayfasından ekleyiniz.");

            RuleFor(x => x.PaymentTypeId)
                .NotNull().WithMessage("ödeme yöntemi seçin")
                .GreaterThanOrEqualTo(1).WithMessage("ödeme yöntemi seçin");
        }
    }
}
