using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Companies;

namespace PurchaseManagament.Application.Concrete.Validators.Companies
{
    public class UpdateCompanyValidator : AbstractValidator<UpdateCompanyRM>
    {
        public UpdateCompanyValidator()
        {
            RuleFor(x => x.Adress).NotEmpty().WithMessage("Şirketin adres bilgisi boş olamaz");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Şirketin isim bilgisi boş olamaz");
            RuleFor(x => x.Id).NotEmpty().WithMessage("Şirkettin numara bilgisi boş olamaz");

        }
    }
}
