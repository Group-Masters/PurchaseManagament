using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.EmployeeRoles;

namespace PurchaseManagament.Application.Concrete.Validators.Employees
{
    public class GetByIdEmployeeValidator : AbstractValidator<GetByEmployeeIdRM>
    {
        public GetByIdEmployeeValidator()
        {
            RuleFor(x => x.EmployeeId).NotEmpty().WithMessage("Kişinin numara bilgisi boş bırakılamaz").GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");

        }
    }
}
