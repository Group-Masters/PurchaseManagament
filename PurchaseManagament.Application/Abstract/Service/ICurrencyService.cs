using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Currency;
using PurchaseManagament.Application.Concrete.Models.RequestModels.MeasuringUnits;
using PurchaseManagament.Application.Concrete.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface ICurrencyService
    {
        Task<Result<long>> CreateCurrency(CreateCurrencyRM createCurrencyRM);
        Task<Result<long>> UpdateCurrency(UpdateCurrencyRM updateCurrencyRM);
        Task<Result<bool>> DeleteCurrencyPermanent(Int64 id); 
        Task<Result<bool>> DeleteCurrency(Int64 id); // IsDeleted Update

        //GET METHODS
        Task<Result<HashSet<CurrencyDTO>>> GetAllCurrency();
    }
}
