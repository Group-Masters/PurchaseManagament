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
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen Tedarikci Adı bilgisini boş bırakmayınız");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Lütfen Adres bilgisini boş bırakmayınız");

        }
    }
}
