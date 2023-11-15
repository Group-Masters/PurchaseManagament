using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;

namespace PurchaseManagament.Application.Concrete.Validators.Currencies
{
    public class GetByIdCurrencyValidator : AbstractValidator<GetByIdVM>
    {
        public GetByIdCurrencyValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Para biriminin numarası boş bırakılamaz").GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı yazınız");
        }
    }
}
