using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.EmployeeRoles;

namespace PurchaseManagament.Application.Concrete.Validators.EmployeeRoles
{
    public class UpdateEmployeeRoleValidator : AbstractValidator<UpdateEmployeeRoleRM>
    {
        public UpdateEmployeeRoleValidator()
        {
            RuleFor(x => x.EmployeeRoleId).NotEmpty().WithMessage("Çalısan numarası boş bırakılamaz").GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");
            RuleFor(x => x.Id).NotEmpty().WithMessage("Çalısan numarası boş bırakılamaz").GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");
            RuleFor(x => x.RoleId).NotEmpty().WithMessage("Çalısan rol numarası boş bırakılamaz").GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");



        }
    }
}
