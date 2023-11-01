using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.RequestModels.MeasuringUnits;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.API.Controllers
{
    public class MeasuringUnitController : Controller
    {
        private readonly IMeasuringUnitService _measuringUnitService;

        public MeasuringUnitController(IMeasuringUnitService measuringUnitService)
        {
            _measuringUnitService = measuringUnitService;
        }

        [HttpPost("CreateMeasuringUnit")]
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

        [HttpGet("GetAllMeasuringUnit")]
        public async Task<IActionResult> GetAllMeasuringUnit()
        {
            var entities = await _measuringUnitService.GetAllMeasuringUnit();
            return Ok(entities);
        }

        [HttpPut("Delete/{id}")]
        public async Task<IActionResult> DeleteMeasuringUnit(Int64 id)
        {
            var entity = await _measuringUnitService.DeleteMeasuringUnit(id);
            return Ok(entity);
        }

        [HttpDelete("DeletePermanent/{id}")]
        public async Task<ActionResult<Result<bool>>> DeleteMeasuringUnitPermanent(Int64 id)
        {
            var result = await _measuringUnitService.DeleteMeasuringUnitPermanent(id);
            return Ok(result);
        }
    }
}
