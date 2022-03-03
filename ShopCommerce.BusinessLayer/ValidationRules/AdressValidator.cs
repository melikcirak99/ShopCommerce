using FluentValidation;
using ShopCommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCommerce.BusinessLayer.ValidationRules
{
    public class AdressValidator : AbstractValidator<Adress>
    {
        public AdressValidator()
        {
            RuleFor(x => x.City)
                .NotEmpty().WithMessage("şehir girin")
                .MinimumLength(2).WithMessage("en az 2 karakter girişi yapın");

            RuleFor(x => x.District)
                .NotEmpty().WithMessage("ilçe girin")
                .MinimumLength(2).WithMessage("en az 2 karakter girişi yapın");

            RuleFor(x => x.Neighborhood)
                .NotEmpty().WithMessage("mahalle girin");

            RuleFor(x => x.Street)
                .NotEmpty().WithMessage("sokak girin")
                .MinimumLength(2).WithMessage("en az 2 karakter girişi yapın");
            RuleFor(x => x.DoorNumber)
                .NotEmpty().WithMessage("kapı numarası girin")
                .MinimumLength(1).WithMessage("en az 1 karakter girişi yapın");


        }
    }
}
