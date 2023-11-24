using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Request;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface IRequestService
    {
        Task<Result<long>> CreateRequest(CreateRequestRM? createRequestRM);
        Task<Result<long>> UpdateRequest(UpdateRequestRM updateRequestRM);
        Task<Result<Request>> RequestStatusUpdate(GetByIdVM getByIdVM);
        Task<Result<bool>> DeleteRequest(GetByIdVM id);
        Task<Result<bool>> DeleteRequestPermanent(GetByIdVM id);

        //GET METHODS

        //get by employee
        //get by companyId and departmentId

        Task<Result<HashSet<RequestDto>>> GetRequestByEmployeeId(GetRequestByEmployeeIdRM getRequestByEmployeeIdRM);
        Task<Result<HashSet<RequestDto>>> GetRequestByCIdDId(GetRequestByCIdDIdRM getRequestByCIdDIdRM);
        Task<Result<HashSet<RequestDto>>> GetPendingRequestByCIdDId(GetRequestByCIdDIdRM getRequestByCIdDIdRM);
        Task<Result<RequestDto>> GetRequestById(GetRequestByIdRM getRequestById);
        Task<Result<HashSet<RequestDto>>> GetAllRequest();
        Task<Result<HashSet<RequestDto>>> GetRequesApprovedtByCompany(GetByIdVM getByIdVM);
    }
}
