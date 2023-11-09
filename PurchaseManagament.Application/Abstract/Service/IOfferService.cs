using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Offers;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface IOfferService
    {
        Task<Result<long>> CreateOffer(CreateOfferRM create);
        Task<Result<long>> UpdateOffer(UpdateOfferRM update);
        Task<Result<long>> UpdateOfferState(UpdateOfferStateRM update);

        Task<Result<bool>> DeleteOffer(Int64 id);
        Task<Result<bool>> DeleteOfferPermanent(Int64 id);

        //GET METHODS
        Task<Result<OfferDto>> GetOfferById(GetOfferByIdRM getOfferById);
        Task<Result<HashSet<OfferDto>>> GetOfferByManager(GetOfferByIdRM companyId);
        Task<Result<HashSet<OfferDto>>> GetOfferByChairman(GetOfferByIdRM companyId);
        Task<Result<HashSet<OfferDto>>> GetOfferByAproved(GetOfferByIdRM companyId);
        Task<Result<HashSet<OfferDto>>> GetOfferFromStock(GetOfferByIdRM companyId);

        Task<Result<HashSet<OfferDto>>> GetAllOffer();
        Task<Result<HashSet<OfferDto>>> GetAllOfferByRequestId(GetOfferByIdRM getOfferByRequestId);

    }
}
