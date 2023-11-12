using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Companies;

namespace PurchaseManagament.Application.Concrete.Validators.Companies
{
    public class UpdateCompanyValidator : AbstractValidator<UpdateCompanyRM>
    {
        public UpdateCompanyValidator()
        {
            RuleFor(x => x.Address).NotEmpty().WithMessage("Şirketin adres bilgisi boş olamaz");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Şirketin isim bilgisi boş olamaz").MaximumLength(50).WithMessage("Bu alan 50 karekterden az sayıda karekter icermelidir");
            RuleFor(x => x.Id).NotEmpty().WithMessage("Şirkettin numara bilgisi boş olamaz").GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");

        }
    }
}
