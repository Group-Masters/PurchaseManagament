using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Request;

namespace PurchaseManagament.Application.Concrete.Validators.Request
{
    public class GetRequestByEmployeeIdValidator : AbstractValidator<GetRequestByEmployeeIdRM>
    {
        public GetRequestByEmployeeIdValidator()
        {
            RuleFor(x => x.RequestEmployeeId).NotEmpty().WithMessage("Lütfen Talep Eden Kullanıcı Id bilgisini boş bırakmayınız");
        }
    }
}
