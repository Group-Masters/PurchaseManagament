﻿using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Suppliers;

namespace PurchaseManagament.Application.Concrete.Validators.Supplier
{
    public class UpdateSupplierValidator : AbstractValidator<UpdateSupplierRM>
    {
        public UpdateSupplierValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Lütfen Tedarikci ID bilgisini boş bırakmayınız");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen Tedarikci Adı bilgisini boş bırakmayınız").MaximumLength(50).WithMessage("Tedarikci Adı Bilgisi 50 Karakterden Fazla Olamaz");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Lütfen Adres bilgisini boş bırakmayınız").MaximumLength(150).WithMessage("Tedarikci Adres Bilgisi 150 Karakterden Fazla Olamaz");

        }
    }
}
