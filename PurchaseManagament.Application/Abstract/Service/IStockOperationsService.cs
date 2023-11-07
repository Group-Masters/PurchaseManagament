using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyStocks;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface IStockOperationsService
    {
        Task CreateStockOperations(UpdateCompanyQuantityAddRM updateCompanyQuantityRM);
        Task<Result<HashSet<StockOperationsDto>>> GetAllStockOperations();
    }
}
