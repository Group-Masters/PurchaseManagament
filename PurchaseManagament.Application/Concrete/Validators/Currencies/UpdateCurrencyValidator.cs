using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Currency;

namespace PurchaseManagament.Application.Concrete.Validators.Currencies
{
    public class UpdateCurrencyValidator : AbstractValidator<UpdateCurrencyRM>
    {
        public UpdateCurrencyValidator()
        {
            RuleFor(x => x.Rate).NotEmpty().WithMessage("Baskınlığı boş bırakalamaz");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Para biriminin ismi boş olamaz");
            RuleFor(x => x.Id).NotEmpty().WithMessage("Para biriminin numarası boş olamaz");


        }
    }
}
