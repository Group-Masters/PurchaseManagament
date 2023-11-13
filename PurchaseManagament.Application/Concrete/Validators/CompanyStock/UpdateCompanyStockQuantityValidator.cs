using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyStocks;

namespace PurchaseManagament.Application.Concrete.Validators.CompanyStock
{
    public class UpdateCompanyStockQuantityValidator : AbstractValidator<UpdateCompanyQuantityAddRM>
    {
        public UpdateCompanyStockQuantityValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Lütfen Stok Id bilgisini boş bırakmayınız").GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");
            RuleFor(x => x.Quantity).NotEmpty().WithMessage("Lütfen Adet bilgisini boş bırakmayınız");
       
        }
    }
}
