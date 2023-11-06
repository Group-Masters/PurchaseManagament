using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;

namespace PurchaseManagament.Application.Concrete.Validators.Employees
{
    public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeVM>
    {
        public UpdateEmployeeValidator()
        {
            RuleFor(x => x.IsActive).NotEmpty().WithMessage("Kişinin aktif bir şekilde çalışıp çaışmadığı hakkında bilgi veren alan boş bırakılamaz");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Kişinin adres bilgisi boş bırakılamaz");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Kişinin telefon bilgisi boş bırakılamaz");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Kişinin E-Posta bilgisi boş bırakılamaz");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kişinin kullanıcı adı boş bırakılamaz");
           
        }
    }
}
