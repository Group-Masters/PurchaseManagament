using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Currency;

namespace PurchaseManagament.Application.Concrete.Validators.Currencies
{
    public class CreateCurrencyValidator : AbstractValidator<CreateCurrencyRM>
    {
        public CreateCurrencyValidator()
        {
            RuleFor(x => x.Rate).NotEmpty()
                .WithMessage("Kur karşılığı boş bırakalamaz");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Para biriminin ismi boş olamaz").MaximumLength(20).WithMessage("Para Birim Adı 20 Karakterden Fazla Olamaz");

        }
    }
}
