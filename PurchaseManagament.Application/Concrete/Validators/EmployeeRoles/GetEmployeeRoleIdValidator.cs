using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.EmployeeRoles;

namespace PurchaseManagament.Application.Concrete.Validators.EmployeeRoles
{
    public class GetEmployeeRoleIdValidator : AbstractValidator<GetByEmployeeIdRM>
    {
        public GetEmployeeRoleIdValidator()
        {
            RuleFor(x => x.EmployeeId).NotEmpty().WithMessage("Çalısan numarası boş bırakılamaz");

        }
    }
}
