using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Departments;

namespace PurchaseManagament.API.Controllers
{
    [Route("Department")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("GetAllDepartment")]
        public async Task<IActionResult> GetAllDepartment()
        {
           var entities = await _departmentService.GetAllDepartment();
            return Ok(entities);
        }
        [HttpPost("GetDepartmentByName")]
        public async Task<IActionResult> GetDepartmentByName(string name)
        {
            var entity = await _departmentService.GetDepartmentByName(name);
            return Ok(entity);
        }
        [HttpPut("UpdateDepartment")]
        public async Task<IActionResult> UpdateDepartment(UpdateDepartmentRM updateDepartmentRM)
        {
            var entity = await _departmentService.UpdateDepartment(updateDepartmentRM);
            return Ok(entity);
        }
        [HttpDelete("DeleteDepartment")]
        public async Task<IActionResult> DeleteDepartment(DeleteDepartmentRM delete)
        {
            var entity = await _departmentService.DeleteDepartment(delete);
            return Ok(entity);
        }
        [HttpPost("CreateDepartment")]
        public async Task<IActionResult> CreateDepartment(CreateDepartmentRM create)
        {
            var entity = await _departmentService.CreateDepartment(create);
            return Ok(entity);
        }
    }
}
