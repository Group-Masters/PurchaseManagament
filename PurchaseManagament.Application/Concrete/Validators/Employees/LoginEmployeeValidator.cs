using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;

namespace PurchaseManagament.Application.Concrete.Validators.Employees
{
    public class LoginEmployeeValidator : AbstractValidator<LoginVM>
    {
        public LoginEmployeeValidator()
        {
            RuleFor(x => x.UsernameOrEmail).NotEmpty().WithMessage("Kişinin kullanıcı adı/postası boş bırakılamaz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Kişinin kullanıcı şifre bilgisi boş bırakılamaz");

        }
    }
}
