using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Offers;

namespace PurchaseManagament.Application.Concrete.Validators.Offer
{
    public class UpdateOfferValidator : AbstractValidator<UpdateOfferRM>
    {
        public UpdateOfferValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Lütfen Teklif Id bilgisini boş bırakmayınız");
            RuleFor(x => x.CurrencyId).NotEmpty().WithMessage("Lütfen Para birim bilgisini boş bırakmayınız");
            RuleFor(x => x.SupplierId).NotEmpty().WithMessage("Lütfen Tedarikci bilgisini boş bırakmayınız");
            RuleFor(x => x.OfferedPrice).NotEmpty().WithMessage("Lütfen Teklif Fiyat bilgisini boş bırakmayınız");
            RuleFor(x => x.Details).MaximumLength(200).WithMessage("Detay Bilgisi 200 Karakterden Fazla Olamaz");
        }
    }
}
