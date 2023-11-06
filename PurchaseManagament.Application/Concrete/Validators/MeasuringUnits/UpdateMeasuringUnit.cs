using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.MeasuringUnits;

namespace PurchaseManagament.Application.Concrete.Validators.MeasuringUnits
{
    public class UpdateMeasuringUnit : AbstractValidator<UpdateMeasuringUnitRM>
    {
        public UpdateMeasuringUnit()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ölçü biriminin ismi boş bırakalamaz");
            RuleFor(x => x.Id).NotEmpty().WithMessage("Ölçü biriminin numarası boş bırakalamaz");

        }
    }
}
