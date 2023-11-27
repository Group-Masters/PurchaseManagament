using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Request;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface IEmployeService
    {
        Task<Result<List<EmployeeDto>>> GetAllEmployes();
        Task<Result<List<EmployeeDto>>> GetEmployeesByCompany(GetByIdVM getByIdVM);
        Task<Result<List<EmployeeDto>>> GetEmployeeIsActiveByCompany(GetByIdVM getByIdVM);
        Task<Result<List<EmployeeDto>>> GetEmployeeIsActiveByCIdDId(GetRequestByCIdDIdRM getByCIdDId);
        Task<Result<EmployeeDto>> GetEmployeeById(GetByIdVM getByIdVM);
        Task<Result<long>> CreateEmployee(CreateEmployeeVM createEmployeeVM);
        Task<Result<TokenDto>> Login2FK(LoginVM2 loginVM);
        Task<Result<bool>> Login(LoginVM loginVM);
        Task<Result<long>> UpdateEmployee(UpdateEmployeeVM updateEmployeeVM);
        Task<Result<long>> UpdateEmployeePassword(UpdatePasswordVM updatePasswordVM);
        Task<Result<bool>> SendPassword(GetByIdVM getByIdVM);
        Task<Result<long>> CreateImage(CreateEmployeeImageVM createEmployeeImageVM);
    }
}
