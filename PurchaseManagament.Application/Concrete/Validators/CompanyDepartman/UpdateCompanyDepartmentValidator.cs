using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyDepartments;

namespace PurchaseManagament.Application.Concrete.Validators.CompanyDepartman
{
    public class UpdateCompanyDepartmentValidator : AbstractValidator<UpdateCompanyDepartmentRM>
    {
        public UpdateCompanyDepartmentValidator()
        {
            RuleFor(x => x.CompanyId).NotEmpty().WithMessage("Lütfen departman Id'yi boş bırakmayınız");
            RuleFor(x => x.DepartmentId).NotEmpty().WithMessage("Lütfen departman Id'yi boş bırakmayınız");
        }
    }
}
