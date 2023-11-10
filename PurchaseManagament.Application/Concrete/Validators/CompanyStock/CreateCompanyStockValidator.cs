using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyStocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Concrete.Validators.CompanyStock
{
    public class CreateCompanyStockValidator : AbstractValidator<CreateCompanyStockRM>
    {
        public CreateCompanyStockValidator()
        {
            RuleFor(x => x.Quantity).NotEmpty().WithMessage("Lütfen Adet bilgisini boş bırakmayınız");
            RuleFor(x => x.CompanyId).NotEmpty().WithMessage("Lütfen Şirket Id'yi boş bırakmayınız").GreaterThan(0)
                .WithMessage("Lütfen 0 dan büyük bir sayı giriniz");
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Lütfen Ürün Id'yi boş bırakmayınız").GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");

        }
    }
}
