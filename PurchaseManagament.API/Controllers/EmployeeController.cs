using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Request;

namespace PurchaseManagament.API.Controllers
{
    [Route("Employee")]
    [Authorize]
    public class EmployeeController : Controller
    {
        private IEmployeService _service;
        public EmployeeController(IEmployeService service)
        {
            _service = service;
        }

        [HttpPost("Create")]
        [Authorize(Roles = "1,8")]
        public async Task<IActionResult> CreateEmployee([FromBody]CreateEmployeeVM createEmployeeVM)
        {
           var entities = await _service.CreateEmployee(createEmployeeVM);
            return Ok(entities);
        }
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginVM loginVM)
        {
            var entities = await _service.Login(loginVM);
            return Ok(entities);
        }
        [AllowAnonymous]
        [HttpPost("Login2fk")]
        public async Task<IActionResult> Login_2f([FromBody] LoginVM2 loginVM)
        {
            var entities = await _service.Login2FK(loginVM);
            return Ok(entities);
        }

        
        [HttpGet("GetAll")]
        [Authorize(Roles = "1,3,9")]
        public async Task<IActionResult> GetAllEmployee()
        {
            var entities = await _service.GetAllEmployes();
            return Ok(entities);
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var entities = await _service.GetEmployeeById(new GetByIdVM { Id=id});
            return Ok(entities);
        }
        [HttpGet("GetByCompany/{id}")]
        [Authorize(Roles = "1,3,9")]
        public async Task<IActionResult> GetByCompanyId(long id)
        {
            var entities = await _service.GetEmployeesByCompany(new GetByIdVM { Id = id });
            return Ok(entities);
        }

        [HttpGet("GetIsActiceByCompany/{id}")]
        [Authorize(Roles = "1,3,9")]
        public async Task<IActionResult> GetEmployeeIsActiveByCompany(long id)
        {
            var entities = await _service.GetEmployeeIsActiveByCompany(new GetByIdVM { Id = id });
            return Ok(entities);
        }

        [HttpGet("GetIsActiveByCompanyDepartment/{id}")]
        [Authorize(Roles = "1,3,9")]
        public async Task<IActionResult> GetEmployeeIsActiveByCIdDId(long companyId, long departmentId)
        {
            var entities = await _service.GetEmployeeIsActiveByCIdDId(new GetRequestByCIdDIdRM { CompanyId = companyId, DepartmentId = departmentId });
            return Ok(entities);
        }

        [HttpPut("Update")]
        [Authorize]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeVM updateEmployeeVM)
        {
            var entities = await _service.UpdateEmployee(updateEmployeeVM);
            return Ok(entities);
        }

        [HttpPut("UpdatePassword")]
        [Authorize]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordVM updatePasswordVM)
        {
            var entities = await _service.UpdateEmployeePassword(updatePasswordVM);
            return Ok(entities);
        }


    }
}
