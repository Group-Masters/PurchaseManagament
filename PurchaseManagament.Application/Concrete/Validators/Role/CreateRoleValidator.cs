using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Roles;

namespace PurchaseManagament.Application.Concrete.Validators.Role
{
    public class CreateRoleValidator : AbstractValidator<CreateRoleRM>
    {
        public CreateRoleValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen Role Adı bilgisini boş bırakmayınız").MaximumLength(20).WithMessage("Rol Adı Bilgisi 20 Karakterden Fazla Olamaz");
        }
    }
}
