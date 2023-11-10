using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Request;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.API.Controllers
{
    [Route("Request")]
    public class RequestController : Controller
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateRequest([FromBody] CreateRequestRM createRequestRM)
        {
            var entity = await _requestService.CreateRequest(createRequestRM);
            return Ok(entity);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateRequestRM update)
        {
            var entity = await _requestService.UpdateRequest(update);
            return Ok(entity);
        }

        [HttpPut("UpdateProductState")]
        public async Task<IActionResult> UpdateProductState([FromBody] UpdateRequestStateRM update)
        {
            var entity = await _requestService.UpdateRequestState(update);
            return Ok(entity);
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<Result<RequestDto>>> GetRequestById(Int64 id)
        {
            var result = await _requestService.GetRequestById(new GetRequestByIdRM { Id = id });
            return Ok(result);
        }
        
        [HttpGet("GetByEmployeeId/{requestemployeeid}")]
        public async Task<ActionResult<Result<HashSet<RequestDto>>>>  GetRequestByEmployeeId(Int64 requestemployeeid)
        {
            var result = await _requestService.GetRequestByEmployeeId(new GetRequestByEmployeeIdRM { RequestEmployeeId = requestemployeeid });
            return Ok(result);
        }
        
        [HttpGet("GetByCIdDId/{companyid}/{departmentid}")]
        public async Task<ActionResult<Result<HashSet<RequestDto>>>> GetRequestByCIdDId(Int64 companyid, Int64 departmentid)
        {
            var result = await _requestService.GetRequestByCIdDId(new GetRequestByCIdDIdRM { CompanyId = companyid, DepartmentId = departmentid });
            return Ok(result);
        }
        
        [HttpGet("GetPendingByCIdDId/{companyid}/{departmentid}")]
        public async Task<ActionResult<Result<HashSet<RequestDto>>>> GetPendingRequestByCIdDId(Int64 companyid, Int64 departmentid)
        {
            var result = await _requestService.GetPendingRequestByCIdDId(new GetRequestByCIdDIdRM { CompanyId = companyid, DepartmentId = departmentid });
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllDepartment()
        {
            var result = await _requestService.GetAllRequest();
            return Ok(result);
        }

        [HttpPut("Delete/{id}")]
        public async Task<IActionResult> UpdateRequest(Int64 id)
        {
            var entity = await _requestService.DeleteRequest(id);
            return Ok(entity);
        }

        [HttpDelete("DeleteRequest/{id}")]
        public async Task<ActionResult<Result<bool>>> DeleteRequestPermanent(Int64 id)
        {
            var result = await _requestService.DeleteRequestPermanent(id);
            return Ok(result);
        }

        [HttpGet("GetApprovedtByCompany/{id}")]
        public async Task<IActionResult> GetRequesApprovedtByCompany(Int64 id)
        {
            var result = await _requestService.GetRequesApprovedtByCompany(new GetByIdVM { Id=id});
            return Ok(result);
        }
    }
}
