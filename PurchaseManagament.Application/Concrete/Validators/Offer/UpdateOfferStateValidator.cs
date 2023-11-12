using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Offers;

namespace PurchaseManagament.Application.Concrete.Validators.Offer
{
    public class UpdateOfferStateValidator : AbstractValidator<UpdateOfferStateRM>
    {
        public UpdateOfferStateValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Lütfen Teklif Id bilgisini boş bırakmayınız").GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Lütfen Teklif Durum bilgisini boş bırakmayınız");
        }
    }
}
