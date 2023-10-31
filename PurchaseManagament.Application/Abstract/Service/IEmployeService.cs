using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface IEmployeService
    {
        Task<Result<List<EmployeeDto>>> GetAllEmployes();
        Task<Result<EmployeeDto>> GetEmployee(GetByIdVM CompanyId);
        Task<Result<long>> CreateEmployee(CreateEmployeeVM createEmployeeVM);

    }
}
