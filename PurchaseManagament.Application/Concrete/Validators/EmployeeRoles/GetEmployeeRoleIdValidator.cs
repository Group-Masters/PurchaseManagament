using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.EmployeeRoles;

namespace PurchaseManagament.Application.Concrete.Validators.EmployeeRoles
{
    public class GetEmployeeRoleIdValidator : AbstractValidator<GetByEmployeeIdRM>
    {
        public GetEmployeeRoleIdValidator()
        {
            RuleFor(x => x.EmployeeId).NotEmpty().WithMessage("Çalısan numarası boş bırakılamaz").GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");

        }
    }
}
