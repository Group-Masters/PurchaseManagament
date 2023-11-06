﻿using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Offers;

namespace PurchaseManagament.Application.Concrete.Validators.Offer
{
    public class UpdateOfferStateValidator : AbstractValidator<UpdateOfferStateRM>
    {
        public UpdateOfferStateValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Lütfen Teklif Id bilgisini boş bırakmayınız");
            RuleFor(x => x.Status).NotNull().WithMessage("Lütfen Teklif Durum bilgisini boş bırakmayınız");
        }
    }
}
