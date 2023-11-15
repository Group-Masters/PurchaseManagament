using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Invoices;

namespace PurchaseManagament.Application.Concrete.Validators.Invoices
{
    public class UpdateInvoiceStatusValidator : AbstractValidator<UpdateInvoiceStatusRM>
    {
        public UpdateInvoiceStatusValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Fatura numarası boş bırakılamaz").GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");

            RuleFor(x => x.Status).NotEmpty().WithMessage("Faturanın durum bilgisi boş bırakılamaz");
        }
    }
}
