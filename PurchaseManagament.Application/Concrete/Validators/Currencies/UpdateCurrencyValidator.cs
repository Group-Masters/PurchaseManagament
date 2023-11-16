using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Currency;

namespace PurchaseManagament.Application.Concrete.Validators.Currencies
{
    public class UpdateCurrencyValidator : AbstractValidator<UpdateCurrencyRM>
    {
        public UpdateCurrencyValidator()
        {
            RuleFor(x => x.Rate).NotEmpty().WithMessage("Kur karşılığı boş bırakalamaz");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Para biriminin ismi boş olamaz").MaximumLength(20).WithMessage("Para Birim Adı Bilgisi 20 Karakterden Fazla Olamaz");
            RuleFor(x => x.Id).NotEmpty().WithMessage("Para biriminin numarası boş olamaz").GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");


        }
    }
}
