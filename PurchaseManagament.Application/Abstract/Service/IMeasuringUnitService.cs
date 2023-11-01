using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.MeasuringUnits;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface IMeasuringUnitService
    {
        Task<Result<long>> CreateMeasuringUnit(CreateMeasuringUnitRM createMeasuringUnitRM);
        Task<Result<long>> UpdateMeasuringUnit(UpdateMeasuringUnitRM updateMeasuringUnitRM);
        Task<Result<bool>> DeleteMeasuringUnitPermanent(Int64 id);
        Task<Result<bool>> DeleteMeasuringUnit(Int64 id);

        //GET METHODS
        Task<Result<HashSet<MeasuringUnitDto>>> GetAllMeasuringUnit();
    }
}
