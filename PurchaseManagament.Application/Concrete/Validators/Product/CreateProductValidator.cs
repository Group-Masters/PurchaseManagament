using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Products;

namespace PurchaseManagament.Application.Concrete.Validators.Product
{
    public class CreateProductValidator : AbstractValidator<CreateProductRM>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.MeasuringUnitId).NotEmpty().WithMessage("Lütfen Ölçü birim bilgisini boş bırakmayınız").GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen Ürün Adı bilgisini boş bırakmayınız").MaximumLength(30).WithMessage("Ürün Adı Bilgisi 30 Karakterden Fazla Olamaz");
            RuleFor(x => x.Description).MaximumLength(200).WithMessage("Ürün Açıklaması 200 Karakterden Fazla Olamaz");
            
        }
    }
}
