using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Offers;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Products;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Request;
using PurchaseManagament.Application.Concrete.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface IRequestService
    {
        Task<Result<long>> CreateRequest(CreateRequestRM createRequestRM);
        Task<Result<long>> UpdateRequest(UpdateRequestRM updateRequestRM);
        Task<Result<long>> UpdateRequestState(UpdateRequestStateRM updateRequestStateRM);
        Task<Result<bool>> DeleteRequest(Int64 id);
        Task<Result<bool>> DeleteRequestPermanent(Int64 id);

        //GET METHODS
        Task<Result<RequestDto>> GetRequestById(GetRequestByIdRM getRequestById);
        Task<Result<HashSet<RequestDto>>> GetAllRequest();
    }
}
