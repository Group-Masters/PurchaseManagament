using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Request;

namespace PurchaseManagament.Application.Concrete.Validators.Request
{
    public class GetRequestByCIdDIdValidator : AbstractValidator<GetRequestByCIdDIdRM>
    {
        public GetRequestByCIdDIdValidator()
        {
            RuleFor(x => x.CompanyId).NotEmpty().WithMessage("Lütfen Şirket Id bilgisini boş bırakmayınız");
            RuleFor(x => x.DepartmentId).NotEmpty().WithMessage("Lütfen Departman Id bilgisini boş bırakmayınız");
        }
    }
}
