using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Request;
using PurchaseManagament.Application.Concrete.Wrapper;

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

        //get by employee
        //get by companyId and departmentId

        Task<Result<HashSet<RequestDto>>> GetRequestByEmployeeId(GetRequestByEmployeeIdRM getRequestByEmployeeIdRM);
        Task<Result<HashSet<RequestDto>>> GetRequestByCIdDId(GetRequestByCIdDIdRM getRequestByCIdDIdRM);
        Task<Result<RequestDto>> GetRequestById(GetRequestByIdRM getRequestById);
        Task<Result<HashSet<RequestDto>>> GetAllRequest();
        Task<Result<HashSet<RequestDto>>> GetRequesApprovedtByCompany(GetByIdVM getByIdVM);
    }
}
