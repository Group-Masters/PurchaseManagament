using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;

namespace PurchaseManagament.Application.Concrete.Validators.Role
{
    public class DeleteRoleValidator : AbstractValidator<GetByIdVM>
    {
        public DeleteRoleValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Lütfen Rol Id'yi boş bırakmayınız").GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");

        }
    }
}
