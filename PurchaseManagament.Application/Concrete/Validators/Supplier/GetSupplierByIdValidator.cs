using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Suppliers;

namespace PurchaseManagament.Application.Concrete.Validators.Supplier
{
    public class GetSupplierByIdValidator : AbstractValidator<GetSupplierByIdRM>
    {
        public GetSupplierByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Lütfen Tedarikci ID bilgisini boş bırakmayınız").GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");

        }
    }
}
