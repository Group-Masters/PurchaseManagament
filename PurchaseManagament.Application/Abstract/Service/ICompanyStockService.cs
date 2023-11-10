using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyStocks;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface ICompanyStockService
    {
        Task<Result<long>> CreateCompanyStock(CreateCompanyStockRM createCompanyStockRM);
        Task<Result<long>> UpdateCompanyStock(UpdateCompanyStockRM updateCompanyStockRM);
        Task<Result<bool>> DeleteCompanyStockPermanent(GetByIdVM id);
        Task<Result<bool>> DeleteCompanyStock(GetByIdVM id);



        //GET METHODS
        Task<Result<HashSet<CompanyStocksDto>>> GetAllCompanyStock();
        Task<Result<CompanyStocksDto>> GetCompanyStockById(GetByIdVM getByIdVM);
        Task<Result<HashSet<CompanyStocksDto>>> GetAllCompanyStockByCompanyId(GetByIdVM getByIdVM);


        Task<Result<long>> UpdateCompanyStockQuantityAdd(UpdateCompanyQuantityAddRM updateCompanyQuantityRM);
        Task<Result<long>> UpdateCompanyStockQuantityReduce(UpdateCompanyQuantityReduceRM updateCompanyQuantityReduceRM);
        Task<Result<long>> ReturnProductToStock(ReturnProductToStockRM returnProductToStockRM);
    }
}
