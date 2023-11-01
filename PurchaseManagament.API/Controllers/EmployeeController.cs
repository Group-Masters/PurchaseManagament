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


        [HttpPost("create")]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeVM createEmployeeVM)
        {
           var entities = await _service.CreateEmployee(createEmployeeVM);
            return Ok(entities);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginVM loginVM)
        {
            var entities = await _service.Login(loginVM);
            return Ok(entities);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllEmployee()
        {
            var entities = await _service.GetAllEmployes();
            return Ok(entities);
        }
    }
}
