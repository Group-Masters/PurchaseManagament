using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;

namespace PurchaseManagament.Application.Concrete.Validators.Departman
{
    public class DeleteDepartmanValidator : AbstractValidator<GetByIdVM>
    {
        public DeleteDepartmanValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Lütfen departman Id'sini boş bırakmayınız").GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");
        }
    }
}
