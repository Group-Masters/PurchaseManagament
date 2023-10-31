using AutoMapper;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Companies;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyDepartments;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Departments;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Roles;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Application.Concrete.Models.RequestModels.EmployeeRoles;

namespace PurchaseManagament.Application.Concrete.AutoMapper
{
    public class RequestModelToDomain : Profile
    {
        public RequestModelToDomain()
        {
            CreateMap<CreateCompanyRM, Company>();
            CreateMap<UpdateCompanyRM, Company>();
            CreateMap<DeleteCompanyRM, Company>();

            CreateMap<CreateCompanyDepartmentRM, CompanyDepartment>();
            CreateMap<DeleteCompanyDepartmentRM, CompanyDepartment>();
            CreateMap<GetCompanyDepartmentByIdRM, CompanyDepartment>();
            CreateMap<UpdateCompanyDepartmentRM, CompanyDepartment>();

            CreateMap<GetByIdDepartmentRM, Department>();
            CreateMap<CreateDepartmentRM, Department>();
            CreateMap<UpdateDepartmentRM, Department>();

            CreateMap<CreateRoleRM, Role>();
            CreateMap<UpdateRoleRM, Role>();
            CreateMap<GetRoleByIdRM, Role>();
            CreateMap<GetRoleByNameRM, Role>();

            CreateMap<CreateEmployeeRoleRM,  EmployeeRole>();
            CreateMap<UpdateEmployeeRoleRM, EmployeeRole>();
            CreateMap<GetByEmployeeIdRM, EmployeeRole>();
            CreateMap<GetByRoleIdRM, EmployeeRole>();
            CreateMap<GetEmployeeRoleByIdRM, EmployeeRole>();

            CreateMap<CreateEmployeeVM, Employee>();
            CreateMap<CreateEmployeeVM, EmployeeDetail>();
        }
    }
}
