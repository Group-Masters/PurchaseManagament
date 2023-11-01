using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Suppliers;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface ISupplierService
    {
        Task<Result<bool>> CreateSupplier(CreateSupplierRM createSupplierRM);
        Task<Result<bool>> UpdateSupplier(UpdateSupplierRM updateSupplierRM);
        Task<Result<bool>> DeleteSupplier(Int64 Id);
        Task<Result<bool>> DeleteSupplierPermanent(Int64 Id);

        Task<Result<SupplierDto>> GetSupplierById(GetSupplierByIdRM getSupplierByIdRM);
        Task<Result<HashSet<SupplierDto>>> GetAllSupplier();
    }
}
