using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Invoices;

namespace PurchaseManagament.Application.Concrete.Validators.Invoices
{
    public class GetInvoiceByIdValidator : AbstractValidator<GetInvoiceByIdRM>
    {
        public GetInvoiceByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Fatura Id Bilgisi Boş Bırakalamaz").GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");

        }
    }
}
