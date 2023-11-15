using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;

namespace PurchaseManagament.Application.Concrete.Validators.CompanyStock
{
    public class GetCompanyStokByCompanyIdValidator : AbstractValidator<GetByIdVM>
    {
        public GetCompanyStokByCompanyIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Lütfen Şirket Id'yi boş bırakmayınız").GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");
        }
    }

}
