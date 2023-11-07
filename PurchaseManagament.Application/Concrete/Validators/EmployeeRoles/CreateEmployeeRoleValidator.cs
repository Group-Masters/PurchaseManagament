using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.EmployeeRoles;

namespace PurchaseManagament.Application.Concrete.Validators.EmployeeRoles
{
    public class CreateEmployeeRoleValidator : AbstractValidator<CreateEmployeeRoleRM>
    {
        public CreateEmployeeRoleValidator()
        {
            RuleFor(x => x.EmployeeId).NotEmpty().WithMessage("Çalısan ID boş bırakılamaz");
            RuleFor(x => x.RoleId).NotEmpty().WithMessage("Çalısan rol numarası boş bırakılamaz");         
        }
    }
}
