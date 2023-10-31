using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Departments;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface IDepartmentService
    {
        //CRUD
        Task<Result<bool>> CreateDepartment(CreateDepartmentRM createDepartmentRM);
        Task<Result<bool>> DeleteDepartment(DeleteDepartmentRM deleteDepartmentRM);
        Task<Result<bool>> UpdateDepartment(UpdateDepartmentRM updateDepartmentRM);

        //GET METHODS
        Task<Result<DepartmentDto>> GetDepartmentByName(string name);
        Task<Result<HashSet<DepartmentDto>>> GetAllDepartment(); 

        
    }
}
