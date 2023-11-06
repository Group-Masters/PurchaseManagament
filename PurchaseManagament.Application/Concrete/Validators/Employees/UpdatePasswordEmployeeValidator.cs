using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;

namespace PurchaseManagament.Application.Concrete.Validators.Employees
{
    public class UpdatePasswordEmployeeValidator : AbstractValidator<UpdatePasswordVM>
    {
        public UpdatePasswordEmployeeValidator()
        {
            RuleFor(x => x.NewPassword).NotEmpty().WithMessage("Yeni şifreniz boş olamaz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Mevcut şifrenizi yanlış veya boş bırakarak girdiniz");
            RuleFor(x => x.RepeateNewPassword).NotEmpty().WithMessage("Lütfen tekrar istenilen şifreyi boş bırakmayın");


        }
    }
}
