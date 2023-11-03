using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;

namespace PurchaseManagament.API.Controllers
{
    [Route("Employee")]
    public class EmployeeController : Controller
    {
        private IEmployeService _service;
        public EmployeeController(IEmployeService service)
        {
            _service = service;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateEmployee([FromBody]CreateEmployeeVM createEmployeeVM)
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

        [Authorize(Roles = "1")]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllEmployee()
        {
            var entities = await _service.GetAllEmployes();
            return Ok(entities);
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entities = await _service.GetEmployeeById(new GetByIdVM { Id=id});
            return Ok(entities);
        }
        [HttpGet("GetByCompany/{id}")]
        public async Task<IActionResult> GetByCompanyId(int id)
        {
            var entities = await _service.GetEmployeesByCompany(new GetByIdVM { Id = id });
            return Ok(entities);
        }
        [HttpGet("GetIsActiceByCompany/{id}")]
        public async Task<IActionResult> GetEmployeeIsActiveByCompany(int id)
        {
            var entities = await _service.GetEmployeeIsActiveByCompany(new GetByIdVM { Id = id });
            return Ok(entities);
        }


        [HttpPut("Update")]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeVM updateEmployeeVM)
        {
            var entities = await _service.UpdateEmployee(updateEmployeeVM);
            return Ok(entities);
        }
        [HttpPut("UpdatePassword")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordVM updatePasswordVM)
        {
            var entities = await _service.UpdateEmployeePassword(updatePasswordVM);
            return Ok(entities);
        }


    }
}
