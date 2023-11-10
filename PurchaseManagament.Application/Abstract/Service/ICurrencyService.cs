using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Currency;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface ICurrencyService
    {
        Task<Result<long>> CreateCurrency(CreateCurrencyRM createCurrencyRM);
        Task<Result<long>> UpdateCurrency(UpdateCurrencyRM updateCurrencyRM);
        Task<Result<bool>> DeleteCurrencyPermanent(GetByIdVM id); 
        Task<Result<bool>> DeleteCurrency(GetByIdVM id); // IsDeleted Update

        //GET METHODS
        Task<Result<HashSet<CurrencyDTO>>> GetAllCurrency();
    }
}
