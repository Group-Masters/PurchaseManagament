using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Offers;

namespace PurchaseManagament.Application.Concrete.Validators.Offer
{
    public class CreateOfferValidator : AbstractValidator<CreateOfferRM>
    {
        public CreateOfferValidator()
        {
            RuleFor(x => x.CurrencyId).NotEmpty().WithMessage("Lütfen Para birim bilgisini boş bırakmayınız").GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");
            RuleFor(x => x.SupplierId).NotEmpty().WithMessage("Lütfen Tedarikci bilgisini boş bırakmayınız").GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");
            RuleFor(x => x.RequestId).NotEmpty().WithMessage("Lütfen Talep Id bilgisini boş bırakmayınız").GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");
            RuleFor(x => x.OfferedPrice).NotEmpty().WithMessage("Lütfen Teklif Fiyat bilgisini boş bırakmayınız").GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");
            RuleFor(x => x.Details).MaximumLength(200).WithMessage("Detay Bilgisi 200 Karakterden Fazla Olamaz");
        }
    }
}
