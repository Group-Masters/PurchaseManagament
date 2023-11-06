using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Request;

namespace PurchaseManagament.Application.Concrete.Validators.Request
{
    public class UpdateRequestStateValidator : AbstractValidator<UpdateRequestStateRM>
    {
        public UpdateRequestStateValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Lütfen Talep ID bilgisini boş bırakmayınız");
            RuleFor(x => x.State).NotNull().WithMessage("Lütfen Talep Durum bilgisini boş bırakmayınız");
        }
    }
}
