using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyDepartments;

namespace PurchaseManagament.Application.Concrete.Validators.CompanyDepartman
{
    public class DeleteCompanyDepartmentValidator : AbstractValidator<DeleteCompanyDepartmentRM>
    {
        public DeleteCompanyDepartmentValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Lütfen departman Id'yi boş bırakmayınız");
        }
    }
}
