using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Roles;

namespace PurchaseManagament.Application.Concrete.Validators.Role
{
    public class GetRoleByIdValidator : AbstractValidator<GetRoleByIdRM>
    {
        public GetRoleByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Lütfen Rol ID bilgisini boş bırakmayınız").GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");
        }
    }
}
