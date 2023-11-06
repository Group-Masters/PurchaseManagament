using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Suppliers;

namespace PurchaseManagament.Application.Concrete.Validators.Supplier
{
    public class UpdateSupplierValidator : AbstractValidator<UpdateSupplierRM>
    {
        public UpdateSupplierValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Lütfen Tedarikci ID bilgisini boş bırakmayınız");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen Tedarikci Adı bilgisini boş bırakmayınız");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Lütfen Adres bilgisini boş bırakmayınız");

        }
    }
}
