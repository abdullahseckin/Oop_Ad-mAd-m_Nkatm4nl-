using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Urun adi bos gecılmez");
            RuleFor(x => x.Price).NotEmpty().WithMessage("fiyat adi bos gecılmez");
            RuleFor(x => x.Stock).NotEmpty().WithMessage("stok adi bos gecılmez");
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("en az 5 karakter giriniz");
        }
    }
}
