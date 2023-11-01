using AutoMapper;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Companies;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyDepartments;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Departments;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Roles;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Application.Concrete.Models.RequestModels.EmployeeRoles;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyStocks;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Products;
using PurchaseManagament.Application.Concrete.Models.RequestModels.MeasuringUnits;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Currency;

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

            CreateMap<CreateProductRM, Product>();
            CreateMap<UpdateProductRM, Product>();

            CreateMap<CreateEmployeeRoleRM,  EmployeeRole>();
            CreateMap<UpdateEmployeeRoleRM, EmployeeRole>();
            CreateMap<GetByEmployeeIdRM, EmployeeRole>();
            CreateMap<GetByRoleIdRM, EmployeeRole>();
            CreateMap<GetEmployeeRoleByIdRM, EmployeeRole>();

            CreateMap<CreateEmployeeVM, Employee>();
            CreateMap<CreateEmployeeVM, EmployeeDetail>();

            CreateMap<CreateCompanyStockRM, CompanyStock>();
            CreateMap<UpdateCompanyStockRM, CompanyStock>();

            CreateMap<CreateMeasuringUnitRM, MeasuringUnit>();
            CreateMap<UpdateMeasuringUnitRM, MeasuringUnit>();

            CreateMap<CreateCurrencyRM, Currency>();
            CreateMap<UpdateCurrencyRM, Currency>();

        }
    }
}
