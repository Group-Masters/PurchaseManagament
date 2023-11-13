using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Offers;

namespace PurchaseManagament.Application.Concrete.Validators.Offer
{
    public class GetOfferByIdValidator : AbstractValidator<GetOfferByIdRM>
    {
        public GetOfferByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Lütfen Teklif ID bilgisini boş bırakmayınız").GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");
        }
    }
}
