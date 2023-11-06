using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyStocks;

namespace PurchaseManagament.Application.Concrete.Validators.CompanyStock
{
    public class UpdateCompanyStockQuantityValidator : AbstractValidator<UpdateCompanyQuantityRM>
    {
        public UpdateCompanyStockQuantityValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Lütfen Stok Id bilgisini boş bırakmayınız");
            RuleFor(x => x.Quantity).NotNull().WithMessage("Lütfen Adet bilgisini boş bırakmayınız");
            RuleFor(x => x.ToplaCıkar).NotNull().WithMessage("Lütfen Islem bilgisini boş bırakmayınız");
            RuleFor(x => x.ReceiverEmployeeId).NotNull().WithMessage("Lütfen Talep Eden Kullanıcı bilgisini boş bırakmayınız");

        }
    }
}
