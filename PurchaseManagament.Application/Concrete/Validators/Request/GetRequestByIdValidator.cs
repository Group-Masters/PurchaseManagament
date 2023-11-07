using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Request;

namespace PurchaseManagament.Application.Concrete.Validators.Request
{
    public class GetRequestByIdValidator : AbstractValidator<GetRequestByIdRM>
    {
        public GetRequestByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Lütfen Talep Id bilgisini boş bırakmayınız");
        }
    }
}
