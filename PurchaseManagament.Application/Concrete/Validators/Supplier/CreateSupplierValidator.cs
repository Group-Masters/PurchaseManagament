using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Concrete.Validators.Supplier
{
    public class CreateSupplierValidator : AbstractValidator<CreateSupplierRM>
    {
        public CreateSupplierValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen Tedarikci Adı bilgisini boş bırakmayınız").MaximumLength(50).WithMessage("Tedarikci Adı Bilgisi 50 Karakterden Fazla Olamaz");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Lütfen Adres bilgisini boş bırakmayınız").MaximumLength(150).WithMessage("Tedarikci Adı Bilgisi 150 Karakterden Fazla Olamaz");

        }
    }

    public class GetSupplierByIdValidator : AbstractValidator<GetSupplierByIdRM>
    {
        public GetSupplierByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Lütfen Tedarikci ID bilgisini boş bırakmayınız");

        }
    }
}
