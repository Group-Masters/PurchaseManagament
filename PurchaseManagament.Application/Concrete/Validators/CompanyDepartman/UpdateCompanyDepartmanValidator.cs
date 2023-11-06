using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyDepartments;

namespace PurchaseManagament.Application.Concrete.Validators.CompanyDepartman
{
    public class UpdateCompanyDepartmanValidator : AbstractValidator<UpdateCompanyDepartmentRM>
    {
        public UpdateCompanyDepartmanValidator()
        {
            RuleFor(x => x.DepartmentId).NotNull().WithMessage("Lütfen departman Id'yi boş bırakmayınız");
            RuleFor(x => x.CompanyId).NotNull().WithMessage("Lütfen Şirket Id'yi boş bırakmayınız");
        }
    }
}
