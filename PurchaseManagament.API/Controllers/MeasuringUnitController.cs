using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Models.RequestModels.MeasuringUnits;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.API.Controllers
{
    [Route("MeasuringUnit")]
    [AllowAnonymous]
    public class MeasuringUnitController : Controller
    {
        private readonly IMeasuringUnitService _measuringUnitService;

        public MeasuringUnitController(IMeasuringUnitService measuringUnitService)
        {
            _measuringUnitService = measuringUnitService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateMeasuringUnit([FromBody] CreateMeasuringUnitRM create)
        {
            var entity = await _measuringUnitService.CreateMeasuringUnit(create);
            return Ok(entity);
        }

        //[HttpPut("Update")]
        //public async Task<IActionResult> UpdateDepartment([FromBody] UpdateCompanyDepartmentRM update)
        //{
        //    var entity = await _companyDepartmentService.UpdateCompanyDepartment(update);
        //    return Ok(entity);
        //}

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllMeasuringUnit()
        {
            var entities = await _measuringUnitService.GetAllMeasuringUnit();
            return Ok(entities);
        }

        [HttpGet("GetUnitByProductId")]
        public async Task<IActionResult> GetMeasuringUnitByProductId(Int64 id)
        {
            var entity = await _measuringUnitService.GetMeasuringUnitByProductId(id);
            return Ok(entity);
        }


        [HttpPut("Delete/{id}")]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> DeleteMeasuringUnit(Int64 id)
        {
            var entity = await _measuringUnitService.DeleteMeasuringUnit(new GetByIdVM { Id = id });
            return Ok(entity);
        }

        [HttpDelete("DeletePermanent/{id}")]
        public async Task<ActionResult<Result<bool>>> DeleteMeasuringUnitPermanent(Int64 id)
        {
            var result = await _measuringUnitService.DeleteMeasuringUnitPermanent(new GetByIdVM { Id = id });
            return Ok(result);
        }
    }
}
