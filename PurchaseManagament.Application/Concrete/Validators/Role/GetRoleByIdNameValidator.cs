using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Roles;

namespace PurchaseManagament.Application.Concrete.Validators.Role
{
    public class GetRoleByIdNameValidator : AbstractValidator<GetRoleByNameRM>
    {
        public GetRoleByIdNameValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen Rol Adı bilgisini boş bırakmayınız");
        }
    }
}
