using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyStocks;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface ICompanyStockService
    {
        Task<Result<long>> CreateCompanyStock(CreateCompanyStockRM createCompanyStockRM);
        Task<Result<long>> UpdateCompanyStock(UpdateCompanyStockRM updateCompanyStockRM);
        Task<Result<bool>> DeleteCompanyStockPermanent(Int64 id);
        Task<Result<bool>> DeleteCompanyStock(Int64 id);

        //GET METHODS
        Task<Result<HashSet<CompanyStocksDto>>> GetAllCompanyStock();
    }
}
