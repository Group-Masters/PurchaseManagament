using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Offers;

namespace PurchaseManagament.Application.Concrete.Validators.Offer
{
    public class GetOfferByIdValidator : AbstractValidator<GetOfferByIdRM>
    {
        public GetOfferByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Lütfen Teklif ID bilgisini boş bırakmayınız");
        }
    }
}
