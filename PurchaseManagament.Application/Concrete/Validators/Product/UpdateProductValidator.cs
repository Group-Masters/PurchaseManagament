using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Products;

namespace PurchaseManagament.Application.Concrete.Validators.Product
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductRM>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Lütfen Ürün ID bilgisini boş bırakmayınız");
            RuleFor(x => x.MeasuringUnitId).NotNull().WithMessage("Lütfen Ölçü birim bilgisini boş bırakmayınız");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen Ürün Adı bilgisini boş bırakmayınız");
        }
    }
}
