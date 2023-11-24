using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Request;

namespace PurchaseManagament.Application.Concrete.Validators.Request
{
    public class CreateRequestValidator : AbstractValidator<CreateRequestRM>
    {
        public CreateRequestValidator()
        {
            RuleFor(x => x.Description).MaximumLength(200).WithMessage("Talep Detay Bilgisi 200 Karakterden Fazla Olamaz");
        }
    }
}
