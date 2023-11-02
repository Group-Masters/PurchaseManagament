using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Offers;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface IOfferService
    {
        Task<Result<long>> CreateOffer(CreateOfferRM create);
        Task<Result<long>> UpdateOffer(UpdateOfferRM update);
        Task<Result<bool>> DeleteOffer(Int64 id);
        Task<Result<bool>> DeleteOfferPermanent(Int64 id);

        //GET METHODS
        Task<Result<HashSet<OfferDto>>> GetAllOffer();
    }
}
