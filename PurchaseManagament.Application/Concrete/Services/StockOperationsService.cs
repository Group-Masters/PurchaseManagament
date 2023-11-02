using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.Application.Concrete.Services
{
    public class StockOperationsService : IStockOperationsService
    {
        public Task<Result<bool>> CreateStockOperations(StockOperationsDto stockOperationsDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Result<HashSet<StockOperationsDto>>> GetAllStockOperations()
        {
            throw new NotImplementedException();
        }
    }
}
