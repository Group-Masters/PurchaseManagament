using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Invoices;

namespace PurchaseManagament.Application.Concrete.Validators.Invoices
{
    public class CreateInvoiceValidator : AbstractValidator<CreateInvoiceRM>
    {
        public CreateInvoiceValidator()
        {
            RuleFor(x => x.OfferId).NotEmpty().WithMessage("Teklif numarası boş bırakalamaz").GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");

        }
    }
}
