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
            RuleFor(x => x.Quantity).NotNull().WithMessage("Lütfen Adet bilgisini boş bırakmayınız");
            RuleFor(x => x.CompanyId).NotNull().WithMessage("Lütfen Şirket Id'yi boş bırakmayınız");
            RuleFor(x => x.ProductId).NotNull().WithMessage("Lütfen Ürün Id'yi boş bırakmayınız");

        }
    }
}
