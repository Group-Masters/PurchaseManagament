using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Offers;

namespace PurchaseManagament.Application.Concrete.Validators.Offer
{
    public class UpdateOfferValidator : AbstractValidator<UpdateOfferRM>
    {
        public UpdateOfferValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Lütfen Teklif Id bilgisini boş bırakmayınız");
            RuleFor(x => x.CurrencyId).NotNull().WithMessage("Lütfen Para birim bilgisini boş bırakmayınız");
            RuleFor(x => x.SupplierId).NotNull().WithMessage("Lütfen Tedarikci bilgisini boş bırakmayınız");
            RuleFor(x => x.OfferedPrice).NotNull().WithMessage("Lütfen Teklif Fiyat bilgisini boş bırakmayınız");
        }
    }
}
