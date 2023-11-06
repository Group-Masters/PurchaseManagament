using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyStocks;

namespace PurchaseManagament.Application.Concrete.Validators.CompanyStock
{
    public class UpdateCompanyStockValidator : AbstractValidator<UpdateCompanyStockRM>
    {
        public UpdateCompanyStockValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Lütfen Stok Id bilgisini boş bırakmayınız");
            RuleFor(x => x.Quantity).NotEmpty().WithMessage("Lütfen Adet bilgisini boş bırakmayınız");
            RuleFor(x => x.CompanyId).NotEmpty().WithMessage("Lütfen Şirket Id'yi boş bırakmayınız");
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Lütfen Ürün Id'yi boş bırakmayınız");

        }
    }
}
