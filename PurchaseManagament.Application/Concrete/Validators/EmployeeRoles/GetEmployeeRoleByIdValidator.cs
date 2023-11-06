using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.EmployeeRoles;

namespace PurchaseManagament.Application.Concrete.Validators.EmployeeRoles
{
    public class GetEmployeeRoleByIdValidator : AbstractValidator<GetEmployeeRoleByIdRM>
    {
        public GetEmployeeRoleByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Çalısan rol numarası boş bırakılamaz");

        }
    }
}
