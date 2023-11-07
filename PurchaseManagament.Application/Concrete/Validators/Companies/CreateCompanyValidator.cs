using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Companies;

namespace PurchaseManagament.Application.Concrete.Validators.Companies
{
    public class CreateCompanyValidator : AbstractValidator<CreateCompanyRM>
    {
        public CreateCompanyValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen şirket ismini boş bırakmayınız").MaximumLength(50).WithMessage("Şirket Adı Bilgisi 50 Karakterden fazla olamaz");
            RuleFor(x => x.Adress).NotEmpty().WithMessage("Lütfen şirket adresini boş bırakmayınız").MaximumLength(150).WithMessage("Adres Bilgisi 150 Karakterden fazla olamaz");

        }
    }
}
