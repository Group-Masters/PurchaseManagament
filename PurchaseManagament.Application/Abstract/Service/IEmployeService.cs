using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface IEmployeService
    {
        Task<Result<List<EmployeeDto>>> GetAllEmployes();
        Task<Result<EmployeeDto>> GetEmployee();
        Task<Result<EmployeeDto>> GetEmployeeById(GetByIdVM getByIdVM);


        Task<Result<long>> CreateEmployee(CreateEmployeeVM createEmployeeVM);
        Task<Result<TokenDto>> Login(LoginVM loginVM);
        Task<Result<long>> UpdateEmployee(UpdateEmployeeVM updateEmployeeVM);
    }
}
