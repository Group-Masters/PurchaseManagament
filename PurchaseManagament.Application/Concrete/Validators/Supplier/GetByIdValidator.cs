using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;

namespace PurchaseManagament.Application.Concrete.Validators.Supplier
{
    public class GetByIdValidator : AbstractValidator<GetByIdVM>
    {
        public GetByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Tedarikçi numarası boş bırakılamaz").GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");

        }
    }
}
