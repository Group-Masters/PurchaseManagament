using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyDepartments;

namespace PurchaseManagament.Application.Concrete.Validators.CompanyDepartman
{
    public class GetCompanyDepartmentByIdValidator : AbstractValidator<GetCompanyDepartmentByIdRM>
    {
        public GetCompanyDepartmentByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Lütfen departman Id'yi boş bırakmayınız");
        }
    }
}
