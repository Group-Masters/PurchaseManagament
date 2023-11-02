using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface IStockOperationsService
    {
        Task<Result<bool>> CreateStockOperations(StockOperationsDto stockOperationsDTO);
        Task<Result<HashSet<StockOperationsDto>>> GetAllStockOperations();
    }
}
