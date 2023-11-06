using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Companies;

namespace PurchaseManagament.Application.Concrete.Validators.Companies
{
    public class DeleteCompanyValidator : AbstractValidator<DeleteCompanyRM>
    {
        public DeleteCompanyValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Şirket numarası boş bırakılamaz");
        }
    }
}
