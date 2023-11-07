using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;

namespace PurchaseManagament.Application.Concrete.Validators.Employees
{
    public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeVM>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kişinin isim bilgisi boş bırakılamaz");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Kişinin adres bilgisi boş bırakılamaz");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Kişinin telefon bilgisi boş bırakılamaz");
            RuleFor(x => x.BirthYear).NotEmpty().WithMessage("Kişinin doğum yılı bilgisi boş bırakılamaz");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Kişinin E-Posta bilgisi boş bırakılamaz");
            RuleFor(x => x.DepartmentId).NotEmpty().WithMessage("Kişinin departman numarası bilgisi boş bırakılamaz");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Kişinin soyadı bilgisi boş bırakılamaz");
            RuleFor(x => x.CompanyId).NotEmpty().WithMessage("Kişinin calıştığı/çalışacağı bilgisi boş bırakılamaz");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kişinin kullanıcı adı boş bırakılamaz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Kişinin kullanıcı şifresi boş bırakılamaz");
        }
    }
}
