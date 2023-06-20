using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Categori adı boş geçilemez");
            RuleFor(x => x.CategoryName).MinimumLength(5).WithMessage("Categori adı enaz 5 karakter giriniz");
           

        }
    }
}
