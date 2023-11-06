using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Request;

namespace PurchaseManagament.Application.Concrete.Validators.Request
{
    public class UpdateRequestValidator : AbstractValidator<UpdateRequestRM>
    {
        public UpdateRequestValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Lütfen Talep ID bilgisini boş bırakmayınız");
            RuleFor(x => x.ProductId).NotNull().WithMessage("Lütfen Ürün Id bilgisini boş bırakmayınız");
            RuleFor(x => x.Quantity).NotNull().WithMessage("Lütfen Adet/Ölcü bilgisini boş bırakmayınız");
        }
    }
}
