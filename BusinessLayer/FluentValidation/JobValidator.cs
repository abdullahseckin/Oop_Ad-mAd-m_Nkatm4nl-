using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class JobValidator:AbstractValidator<Job>
    {
        public JobValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("kategorı adi bos gecılmez");            
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("en az 5 karakter giriniz");
        }
    }
}
