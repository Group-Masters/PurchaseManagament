using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyStocks;

namespace PurchaseManagament.Application.Concrete.Validators.CompanyStock
{
    public class ReturnProductToStockValidator : AbstractValidator<ReturnProductToStockRM>
    {
        public ReturnProductToStockValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Lütfen Stok/Islem ID bilgisini boş bırakmayınız").GreaterThan(0)
                .WithMessage("Lütfen 0 dan büyük bir sayı giriniz");
            RuleFor(x => x.Quantity).NotEmpty().WithMessage("Lütfen Adet bilgisini boş bırakmayınız").GreaterThan(0)
                .WithMessage("Lütfen 0 dan büyük bir sayı giriniz");
            RuleFor(x => x.CompanyStockId).NotEmpty().WithMessage("Lütfen Şirket/Stok ID'yi boş bırakmayınız").GreaterThan(0)
                .WithMessage("Lütfen 0 dan büyük bir sayı giriniz");
            RuleFor(x => x.Quantity).NotEmpty().WithMessage("Lütfen Adte Bilgisini boş bırakmayınız");
        }
    }

}
