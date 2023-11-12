using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Request;

namespace PurchaseManagament.Application.Concrete.Validators.Request
{
    public class GetRequestByCIdDIdValidator : AbstractValidator<GetRequestByCIdDIdRM>
    {
        public GetRequestByCIdDIdValidator()
        {
            RuleFor(x => x.CompanyId).NotEmpty().WithMessage("Lütfen Şirket Id bilgisini boş bırakmayınız").GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");
            RuleFor(x => x.DepartmentId).NotEmpty().WithMessage("Lütfen Departman Id bilgisini boş bırakmayınız").GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");
        }
    }
}
