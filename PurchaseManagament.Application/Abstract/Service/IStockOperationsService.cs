using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Suppliers;
using PurchaseManagament.Application.Concrete.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface IStockOperationsService
    {
        Task<Result<bool>> CreateStockOperations(StockOperationsDTO stockOperationsDTO);
        Task<Result<HashSet<StockOperationsDTO>>> GetAllStockOperations();
    }
}
