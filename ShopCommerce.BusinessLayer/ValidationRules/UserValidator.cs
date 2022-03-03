using FluentValidation;
using ShopCommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCommerce.BusinessLayer.ValidationRules
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("isim girin")
                .MinimumLength(2).WithMessage("en az 2 karakter girişi yapın");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("soyisim girin")
                .MinimumLength(2).WithMessage("en az 2 karakter girişi yapın");

            RuleFor(x => x.Mail)
                .EmailAddress().WithMessage("geçerli bir email adresi girin")
                .NotEmpty().WithMessage("mail girin");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("şifre girin")
                .MinimumLength(8).WithMessage("en az 8 karakter girişi yapın")
                .MaximumLength(20).WithMessage("en fazla 20 karakter girişi yapın");
            

        }
    }
}
