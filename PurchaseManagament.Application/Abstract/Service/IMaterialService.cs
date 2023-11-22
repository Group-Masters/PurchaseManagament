using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Materials;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface IMaterialService
    {
        Task<Result<long>> CreateMaterial(CreateMaterialRM createMaterialRM);
        Task<Result<long>> UpdateMaterial(UpdateMaterialRM updateMaterialRM);
        Task<Result<bool>> DeleteMaterial(GetByIdVM id);
        Task<Result<bool>> DeleteMaterialPermanent(GetByIdVM id);

        Task<Result<HashSet<MaterialDto>>> GetMaterialByEmployeeId(GetByIdVM getMaterialByEmployeeIdRM);
        Task<Result<HashSet<MaterialDto>>> GetMaterialByRequestId(GetByIdVM getMaterialByRequestIdRM);
        Task<Result<MaterialDto>> GetMaterialById(GetByIdVM getMaterialById);
        Task<Result<HashSet<MaterialDto>>> GetAllMaterial();
    }
}
