using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Concrete.Validators.Product
{
    public class CreateProductValidator : AbstractValidator<CreateProductRM>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.MeasuringUnitId).NotEmpty().WithMessage("Lütfen Ölçü birim bilgisini boş bırakmayınız");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen Ürün Adı bilgisini boş bırakmayınız");
        }
    }
}
