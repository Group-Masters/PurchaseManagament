﻿using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Departments;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface IDepartmentService
    {
        //CRUD
        Task<Result<bool>> CreateDepartment(CreateDepartmentRM createDepartmentRM);
        Task<Result<bool>> UpdateDepartment(UpdateDepartmentRM updateDepartmentRM);
        Task<Result<bool>> DeleteDepartmentPermanent(GetByIdVM Id);
        Task<Result<bool>> DeleteDepartment(GetByIdVM Id);

        //GET METHODS
        Task<Result<DepartmentDto>> GetDepartmentById(GetByIdDepartmentRM getByIdDepartmentRM);
        Task<Result<HashSet<DepartmentDto>>> GetAllDepartment(); 
    }
}
