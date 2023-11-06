using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.MeasuringUnits;

namespace PurchaseManagament.Application.Concrete.Validators.MeasuringUnits
{
    public class CreateMeasuringUnit : AbstractValidator<CreateMeasuringUnitRM>
    {
        public CreateMeasuringUnit()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ölçü biriminin ismi boş bırakalamaz");
        }
    }
}
