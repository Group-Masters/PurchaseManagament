using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Roles;

namespace PurchaseManagament.Application.Concrete.Validators.Role
{
    public class UpdateRoleValidator : AbstractValidator<UpdateRoleRM>
    {
        public UpdateRoleValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Lütfen Role ID bilgisini boş bırakmayınız");
            RuleFor(x => x.Name).NotNull().WithMessage("Lütfen Role Adı bilgisini boş bırakmayınız");
        }
    }
}
