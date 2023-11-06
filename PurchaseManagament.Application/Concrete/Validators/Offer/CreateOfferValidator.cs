using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Concrete.Validators.Offer
{
    public class CreateOfferValidator : AbstractValidator<CreateOfferRM>
    {
        public CreateOfferValidator()
        {
            RuleFor(x => x.CurrencyId).NotEmpty().WithMessage("Lütfen Para birim bilgisini boş bırakmayınız");
            RuleFor(x => x.SupplierId).NotEmpty().WithMessage("Lütfen Tedarikci bilgisini boş bırakmayınız");
            RuleFor(x => x.RequestId).NotEmpty().WithMessage("Lütfen Talep Id bilgisini boş bırakmayınız");
            RuleFor(x => x.OfferedPrice).NotEmpty().WithMessage("Lütfen Teklif Fiyat bilgisini boş bırakmayınız");
        }
    }
}
