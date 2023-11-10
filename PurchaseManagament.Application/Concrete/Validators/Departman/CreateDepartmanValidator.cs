using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Departments;

namespace PurchaseManagament.Application.Concrete.Validators.Departman
{
    public class CreateDepartmanValidator : AbstractValidator<CreateDepartmentRM>
    {
        public CreateDepartmanValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen departman ismini boş bırakmayınız").MaximumLength(50).WithMessage("Departman Adı Bilgisi 50 Karakterden Fazla Olamaz");
        }
    }
}
