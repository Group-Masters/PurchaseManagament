using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Request;

namespace PurchaseManagament.Application.Concrete.Validators.Request
{
    public class CreateRequestValidator : AbstractValidator<CreateRequestRM>
    {
        public CreateRequestValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Lütfen Ürün Id bilgisini boş bırakmayınız").GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");
            RuleFor(x => x.Quantity).NotEmpty().WithMessage("Lütfen Adet/Ölcü bilgisini boş bırakmayınız");
            RuleFor(x => x.Details).MaximumLength(200).WithMessage("Talep Detay Bilgisi 200 Karakterden Fazla Olamaz");
        }
    }
}
