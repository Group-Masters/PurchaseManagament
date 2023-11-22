using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Models.RequestModels.MaterialOffers;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface IMaterialOfferService
    {
        Task<Result<long>> CreateMaterialOffer(CreateMaterialOfferRM createMaterialOfferRM);
        Task<Result<long>> UpdateMaterialOffer(UpdateMaterialOfferRM updateMaterialOfferRM);
        Task<Result<bool>> DeleteMaterialOffer(GetByIdVM id);
        Task<Result<bool>> DeleteMaterialOfferPermanent(GetByIdVM id);

        Task<Result<HashSet<MaterialOfferDto>>> GetMaterialOfferByRequestId(GetByIdVM getMaterialOfferByRequestIdRM);
        Task<Result<HashSet<MaterialOfferDto>>> GetMaterialOfferByOfferId(GetByIdVM getMaterialOfferByOfferIdRM);
        Task<Result<HashSet<MaterialOfferDto>>> GetMaterialOfferByMaterialId(GetByIdVM getMaterialOfferByMaterialIdRM);
        Task<Result<MaterialOfferDto>> GetMaterialOfferById(GetByIdVM getMaterialOfferById);
        Task<Result<HashSet<MaterialOfferDto>>> GetAllMaterialOffer();
    }
}
