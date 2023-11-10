using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.EmployeeRoles;

namespace PurchaseManagament.Application.Concrete.Validators.EmployeeRoles
{
    public class GetByRoleIdValidator : AbstractValidator<GetByRoleIdRM>
    {
        public GetByRoleIdValidator()
        {
            RuleFor(x => x.RoleId).NotEmpty().WithMessage("Çalısan rol numarası boş bırakılamaz").GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");

        }
    }
}
