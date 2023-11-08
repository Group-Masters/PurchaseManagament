using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Departments;

namespace PurchaseManagament.Application.Concrete.Validators.Departman
{
    public class GetByIdDepartmentValidator : AbstractValidator<GetByIdDepartmentRM>
    {
        public GetByIdDepartmentValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Lütfen departman Id'yi boş bırakmayınız");

        }
    }
}
