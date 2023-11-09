using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface IStockOperationsService
    {
        Task<Result<HashSet<StockOperationsDto>>> GetAllStockOperations();
        Task<Result<HashSet<StockOperationsDto>>> GetStockOperationsByEmployeeId(GetByIdVM getByIdVM);
        Task<Result<HashSet<StockOperationsDto>>> GetStockOperationsByDepartmentId(GetByIdVM getByIdVM);
        Task<Result<HashSet<StockOperationsDto>>> GetStockOperationsByCompanyId(GetByIdVM getByIdVM);
    }
}
