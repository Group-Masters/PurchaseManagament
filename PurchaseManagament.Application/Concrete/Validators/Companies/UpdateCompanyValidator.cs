using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Companies;

namespace PurchaseManagament.Application.Concrete.Validators.Companies
{
    public class UpdateCompanyValidator : AbstractValidator<UpdateCompanyRM>
    {
        public UpdateCompanyValidator()
        {
            RuleFor(x => x.Adress).NotEmpty().WithMessage("Şirketin adres bilgisi boş olamaz").MaximumLength(150).WithMessage("Adres Bilgisi 150 Karakterden Fazla Olamaz");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Şirketin isim bilgisi boş olamaz").MaximumLength(50).WithMessage("Şirket Adı Bilgisi 50 Karakterden Fazla Olamaz");
            RuleFor(x => x.Id).NotEmpty().WithMessage("Şirkettin ID bilgisi boş olamaz");

        }
    }
}
