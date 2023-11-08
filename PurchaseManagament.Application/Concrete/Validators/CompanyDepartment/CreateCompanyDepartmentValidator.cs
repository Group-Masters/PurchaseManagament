using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyDepartments;

namespace PurchaseManagament.Application.Concrete.Validators.CompanyDepartman
{
    public class CreateCompanyDepartmentValidator : AbstractValidator<CreateCompanyDepartmanRM>
    {
        public CreateCompanyDepartmentValidator()
        {
            RuleFor(x => x.DepartmentId).NotEmpty().WithMessage("Lütfen departman Id'yi boş bırakmayınız");
            RuleFor(x => x.CompanyId).NotEmpty().WithMessage("Lütfen Şirket Id'yi boş bırakmayınız");
        }
    }
}
