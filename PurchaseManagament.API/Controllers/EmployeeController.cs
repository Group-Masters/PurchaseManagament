using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;

namespace PurchaseManagament.API.Controllers
{
    [Route("employee")]
    public class EmployeeController : Controller
    {
        private IEmployeService _service;
        public EmployeeController(IEmployeService service)
        {
            _service = service;
        }


        [HttpPost("createEmployee")]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeVM createEmployeeVM)
        {
           var entities = await _service.CreateEmployee(createEmployeeVM);
            return Ok(entities);
        }

        [HttpGet("GetAllEmployee/id")]
        public async Task<IActionResult> GetAllEmployee()
        {
            var entities = await _service.GetAllEmployes();
            return Ok(entities);
        }
    }
}
