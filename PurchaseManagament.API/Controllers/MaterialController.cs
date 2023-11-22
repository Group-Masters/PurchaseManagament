using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Materials;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.API.Controllers
{
    [Route("Material")]

    public class MaterialController : Controller
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateMaterial([FromBody] CreateMaterialRM createMaterialRM)
        {
            var result = await _materialService.CreateMaterial(createMaterialRM);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateMaterial([FromBody] UpdateMaterialRM update)
        {
            var entity = await _materialService.UpdateMaterial(update);
            return Ok(entity);
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<Result<MaterialDto>>> GetMaterialById(Int64 id)
        {
            var result = await _materialService.GetMaterialById(new GetByIdVM { Id = id });
            return Ok(result);
        }

        [HttpGet("GetByEmployeeId/{employeeid}")]
        public async Task<ActionResult<Result<HashSet<MaterialDto>>>> GetMaterialByEmployeeId(Int64 employeeId)
        {
            var result = await _materialService.GetMaterialByEmployeeId(new GetByIdVM { Id = employeeId });
            return Ok(result);
        }

        [HttpGet("GetByRequestId/{requestid}")]
        public async Task<ActionResult<Result<HashSet<MaterialDto>>>> GetMaterialByRequestId(Int64 requestId)
        {
            var result = await _materialService.GetMaterialByRequestId(new GetByIdVM { Id = requestId });
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllMaterial()
        {
            var result = await _materialService.GetAllMaterial();
            return Ok(result);
        }

        [HttpPut("Delete/{id}")]
        public async Task<IActionResult> DeleteMaterial(Int64 id)
        {
            var result = await _materialService.DeleteMaterial(new GetByIdVM { Id = id });
            return Ok(result);
        }

        [HttpDelete("DeleteMaterial/{id}")]
        public async Task<ActionResult<Result<bool>>> DeleteMaterialPermanent(Int64 id)
        {
            var result = await _materialService.DeleteMaterialPermanent(new GetByIdVM { Id = id });
            return Ok(result);
        }
    }
}
