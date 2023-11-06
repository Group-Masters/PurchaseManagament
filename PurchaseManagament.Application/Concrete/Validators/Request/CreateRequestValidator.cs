using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Concrete.Validators.Request
{
    public class CreateRequestValidator : AbstractValidator<CreateRequestRM>
    {
        public CreateRequestValidator()
        {
            RuleFor(x => x.ProductId).NotNull().WithMessage("Lütfen Ürün Id bilgisini boş bırakmayınız");
            RuleFor(x => x.Quantity).NotNull().WithMessage("Lütfen Adet/Ölcü bilgisini boş bırakmayınız");
        }
    }
}
