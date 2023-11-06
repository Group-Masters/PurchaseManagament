using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.EmployeeRoles;

namespace PurchaseManagament.Application.Concrete.Validators.EmployeeRoles
{
    public class GetByRoleIdValidator : AbstractValidator<GetByRoleIdRM>
    {
        public GetByRoleIdValidator()
        {
            RuleFor(x => x.RoleId).NotEmpty().WithMessage("Çalısan rol numarası boş bırakılamaz");

        }
    }
}
