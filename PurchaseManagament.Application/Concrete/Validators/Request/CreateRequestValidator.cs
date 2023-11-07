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
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Lütfen Ürün Id bilgisini boş bırakmayınız");
            RuleFor(x => x.Quantity).NotEmpty().WithMessage("Lütfen Adet/Ölcü bilgisini boş bırakmayınız");
            RuleFor(x => x.Details).MaximumLength(200).WithMessage("Talep Detay Bilgisi 200 Karakterden Fazla Olamaz");
        }
    }
}
