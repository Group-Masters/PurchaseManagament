using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Departments;

namespace PurchaseManagament.Application.Concrete.Validators.Departman
{
    public class UpdateDepartmanValidator : AbstractValidator<UpdateDepartmentRM>
    {
        public UpdateDepartmanValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Lütfen departman Id'sini boş bırakmayınız");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen departman ismini boş bırakmayınız").MaximumLength(50).WithMessage("Departman Adı Bilgisi 50 Karakterden Fazla Olamaz");
        }
    }
}
