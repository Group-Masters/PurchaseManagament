using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Invoices;

namespace PurchaseManagament.Application.Concrete.Validators.Invoices
{
    public class CreateInvoiceValidator : AbstractValidator<CreateInvoiceRM>
    {
        public CreateInvoiceValidator()
        {
            RuleFor(x => x.OfferId).NotEmpty().WithMessage("Teklif numarası boş bırakalamaz");

        }
    }
}
