using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Roles;

namespace PurchaseManagament.Application.Concrete.Validators.Role
{
    public class UpdateRoleValidator : AbstractValidator<UpdateRoleRM>
    {
        public UpdateRoleValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Lütfen Role ID bilgisini boş bırakmayınız").GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen Role Adı bilgisini boş bırakmayınız").MaximumLength(20).WithMessage("Rol Adı Bilgisi 20 Karakterden Fazla Olamaz");
        }
    }
}
