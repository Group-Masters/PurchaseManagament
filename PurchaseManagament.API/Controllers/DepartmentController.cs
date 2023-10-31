using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Departments;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Roles;
using PurchaseManagament.Application.Concrete.Services;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.API.Contdepartmanlers
{
    [Route("Department")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpPost("CreateDepartment")]
        public async Task<IActionResult> CreateDepartment(CreateDepartmentRM create)
        {
            var entity = await _departmentService.CreateDepartment(create);
            return Ok(entity);
        }

        [HttpPut("UpdateDepartment")]
        public async Task<IActionResult> UpdateDepartment(UpdateDepartmentRM updateDepartmentRM)
        {
            var entity = await _departmentService.UpdateDepartment(updateDepartmentRM);
            return Ok(entity);
        }

        [HttpGet("GetDepartmentById")]
        public async Task<ActionResult<Result<DepartmentDto>>> GetByIdDepartment(Int64 id)
        {
            var result = await _departmentService.GetDepartmentById(new GetByIdDepartmentRM { Id = id });
            return Ok(result);
        }

        [HttpGet("GetAllDepartment")]
        public async Task<IActionResult> GetAllDepartment()
        {
           var entities = await _departmentService.GetAllDepartment();
            return Ok(entities);
        }

        //Istenmeyen Ozellik
        //[HttpPost("GetDepartmentByName")]
        //public async Task<IActionResult> GetDepartmentByName(string name)
        //{
        //    var entity = await _departmentService.GetDepartmentByName(name);
        //    return Ok(entity);
        //}

        [HttpPut("DeleteDepartment")]
        public async Task<ActionResult<Result<bool>>> DeleteDepartment(Int64 Id)
        {
            var result = await _departmentService.DeleteDepartment(Id);
            return Ok(result);
        }

        [HttpDelete("DeletePermanentDepartment")]
        public async Task<ActionResult<Result<bool>>> DeleteDepartmentPermanent(Int64 Id)
        {
            var result = await _departmentService.DeleteDepartmentPermanent(Id);
            return Ok(result);
        }
    }
}
