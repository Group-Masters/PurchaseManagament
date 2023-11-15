using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyDepartments;

namespace PurchaseManagament.Application.Concrete.Validators.CompanyDepartman
{
    public class GetDepartmentByCompanyIdRMValidator : AbstractValidator<GetDepartmentByCompanyIdRM>
    {
        public GetDepartmentByCompanyIdRMValidator()
        {
            RuleFor(x => x.CompanyId).NotEmpty().WithMessage("Lütfen şirket Id'yi boş bırakmayınız").GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");
        }
    }
}
