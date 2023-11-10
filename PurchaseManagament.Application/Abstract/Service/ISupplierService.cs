using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Suppliers;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface ISupplierService
    {
        Task<Result<bool>> CreateSupplier(CreateSupplierRM createSupplierRM);
        Task<Result<bool>> UpdateSupplier(UpdateSupplierRM updateSupplierRM);
        Task<Result<bool>> DeleteSupplier(GetByIdVM Id);
        Task<Result<bool>> DeleteSupplierPermanent(GetByIdVM Id);

        Task<Result<SupplierDto>> GetSupplierById(GetSupplierByIdRM getSupplierByIdRM);
        Task<Result<HashSet<SupplierDto>>> GetAllSupplier();
    }
}
