using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;

namespace PurchaseManagament.Application.Concrete.Validators.Employees
{
    public class GetByIdEmployeeValidator : AbstractValidator<GetByIdVM>
    {
        public GetByIdEmployeeValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Kişinin numara bilgisi boş bırakılamaz").GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");

        }
    }
}
