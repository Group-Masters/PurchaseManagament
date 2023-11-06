using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Departments;

namespace PurchaseManagament.Application.Concrete.Validators.Departman
{
    public class UpdateDepartmanValidator : AbstractValidator<UpdateDepartmentRM>
    {
        public UpdateDepartmanValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Lütfen departman Id'sini boş bırakmayınız");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen departman ismini boş bırakmayınız");
        }
    }
}
