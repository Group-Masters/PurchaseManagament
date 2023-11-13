using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Request;

namespace PurchaseManagament.Application.Concrete.Validators.Request
{
    public class GetRequestByIdValidator : AbstractValidator<GetRequestByIdRM>
    {
        public GetRequestByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Lütfen Talep Id bilgisini boş bırakmayınız").GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");
        }
    }
}
