using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyDepartments;

namespace PurchaseManagament.Application.Concrete.Validators.CompanyDepartman
{
    public class GetDepartmentByCompanyIdRMValidator : AbstractValidator<GetDepartmentByCompanyIdRM>
    {
        public GetDepartmentByCompanyIdRMValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Lütfen departman Id'yi boş bırakmayınız");
        }
    }
}
