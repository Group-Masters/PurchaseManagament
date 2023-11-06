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
            RuleFor(x => x.CurrencyId).NotNull().WithMessage("Lütfen Para birim bilgisini boş bırakmayınız");
            RuleFor(x => x.SupplierId).NotNull().WithMessage("Lütfen Tedarikci bilgisini boş bırakmayınız");
            RuleFor(x => x.RequestId).NotNull().WithMessage("Lütfen Talep Id bilgisini boş bırakmayınız");
            RuleFor(x => x.OfferedPrice).NotNull().WithMessage("Lütfen Teklif Fiyat bilgisini boş bırakmayınız");
        }
    }
}
