using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;

namespace PurchaseManagament.Application.Concrete.Validators.Employees
{
    public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeVM>
    {
        public UpdateEmployeeValidator()
        {
            RuleFor(x => x.IsActive).NotEmpty().WithMessage("Kişinin aktif bir şekilde çalışıp çaışmadığı hakkında bilgi veren alan boş bırakılamaz");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Kişinin adres bilgisi boş bırakılamaz").MaximumLength(200).WithMessage("Adres Bilgisi 200 Karakterden Fazla Olamaz");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Kişinin telefon bilgisi boş bırakılamaz").MaximumLength(20).WithMessage("Telefon Bilgisi 20 Karakterden Fazla Olamaz");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Kişinin E-Posta bilgisi boş bırakılamaz").MaximumLength(150).WithMessage("E-Posta Bilgisi 150 Karakterden Fazla Olamaz");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kişinin kullanıcı adı boş bırakılamaz").MaximumLength(50).WithMessage("Kullanıcı Adı Bilgisi 50 Karakterden Fazla Olamaz");
           
        }
    }
}
