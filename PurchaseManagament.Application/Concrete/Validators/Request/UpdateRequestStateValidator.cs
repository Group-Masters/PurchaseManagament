using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Request;

namespace PurchaseManagament.Application.Concrete.Validators.Request
{
    public class UpdateRequestStateValidator : AbstractValidator<UpdateRequestStateRM>
    {
        public UpdateRequestStateValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Lütfen Talep ID bilgisini boş bırakmayınız").GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");
        }
    }
}
