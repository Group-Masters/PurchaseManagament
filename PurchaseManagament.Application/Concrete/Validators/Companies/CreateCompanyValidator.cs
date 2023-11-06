using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Companies;

namespace PurchaseManagament.Application.Concrete.Validators.Companies
{
    public class CreateCompanyValidator : AbstractValidator<CreateCompanyRM>
    {
        public CreateCompanyValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen şirket ismini boş bırakmayınız");
            RuleFor(x => x.Adress).NotEmpty().WithMessage("Lütfen şirket adresini boş bırakmayınız");

        }
    }
}
