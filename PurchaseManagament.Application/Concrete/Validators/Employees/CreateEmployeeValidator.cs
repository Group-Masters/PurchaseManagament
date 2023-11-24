using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;

namespace PurchaseManagament.Application.Concrete.Validators.Employees
{
    public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeVM>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Kişinin isim bilgisi boş bırakılamaz")
                .MaximumLength(20).WithMessage("Ad Bilgisi 20 Karakterden Fazla Olamaz");
            RuleFor(x => x.Address)
               
                .MaximumLength(200).WithMessage("Adres Bilgisi 200 Karakterden Fazla Olamaz");
            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Kişinin telefon bilgisi boş bırakılamaz")
                .MinimumLength(10).WithMessage("Telefon Bilgisi 10 Karakterden Az Olamaz")
                .MaximumLength(20).WithMessage("Telefon Bilgisi 20 Karakterden Fazla Olamaz")
                .Must(Isnumber).WithMessage("kimlik bilgisi için uygun karakter değildir."); 
            RuleFor(x => x.BirthYear)
                .NotEmpty().WithMessage("Kişinin doğum yılı bilgisi boş bırakılamaz")
                .MaximumLength(4).WithMessage("Doğum Yılı Bilgisi 4 Karakterden Fazla Olamaz")
                 .Must(Isnumber).WithMessage("kimlik bilgisi için uygun karakter değildir."); ;
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Kişinin E-Posta bilgisi boş bırakılamaz")
                .MaximumLength(150).WithMessage("E-Posta Bilgisi 150 Karakterden Fazla Olamaz")
                .EmailAddress().WithMessage("Geçerli bir e-posta girmelisiniz");
            RuleFor(x => x.DepartmentId)
                .NotNull().WithMessage("departmen null olamaz")
                .NotEmpty().WithMessage("Kişinin departman numarası bilgisi boş bırakılamaz")
                .GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");
            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Kişinin soyadı bilgisi boş bırakılamaz")
                .MaximumLength(20).WithMessage("Soyad Bilgisi 20 Karakterden Fazla Olamaz");
            RuleFor(x => x.CompanyId)
                .NotEmpty().WithMessage("Kişinin calıştığı/çalışacağı bilgisi boş bırakılamaz")
                .GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Kişinin kullanıcı adı boş bırakılamaz");
            
 
            RuleFor(x => x.IdNumber)
                .NotEmpty().WithMessage("Kişinin kullanıcı şifresi boş bırakılamaz")
                .MaximumLength(11).WithMessage("Kimlik Numaranız 11 Karakterden Fazla Olamaz")
                .Must(Isnumber).WithMessage("kimlik bilgisi için uygun karakter değildir."); ;

        }
        private bool Isnumber(string text)
        {
            bool result = true;
            foreach (var item in text)
            {
                result = Char.IsNumber(item);
                if (result == false)
                    break;
            }
            return result;
        }
    }
}
