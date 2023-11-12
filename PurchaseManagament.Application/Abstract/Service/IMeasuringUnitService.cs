using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Models.RequestModels.MeasuringUnits;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface IMeasuringUnitService
    {
        Task<Result<long>> CreateMeasuringUnit(CreateMeasuringUnitRM createMeasuringUnitRM);
        Task<Result<long>> UpdateMeasuringUnit(UpdateMeasuringUnitRM updateMeasuringUnitRM);
        Task<Result<bool>> DeleteMeasuringUnitPermanent(GetByIdVM id);
        Task<Result<bool>> DeleteMeasuringUnit(GetByIdVM id);

        //GET METHODS
        Task<Result<HashSet<MeasuringUnitDto>>> GetAllMeasuringUnit();
        Task<Result<MeasuringUnitDto>> GetMeasuringUnitByProductId(Int64 id);


    }
}
