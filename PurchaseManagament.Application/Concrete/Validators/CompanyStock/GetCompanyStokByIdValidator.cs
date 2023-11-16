using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;

namespace PurchaseManagament.Application.Concrete.Validators.CompanyStock
{
    public class GetCompanyStokByIdValidator : AbstractValidator<GetByIdVM>
    {
        public GetCompanyStokByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Lütfen Stok Id'yi boş bırakmayınız").GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");
        }
    }

}
