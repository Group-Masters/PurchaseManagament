using AutoMapper;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Companies;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyDepartments;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyStocks;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Currency;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Departments;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Models.RequestModels.EmployeeRoles;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Invoices;
using PurchaseManagament.Application.Concrete.Models.RequestModels.MeasuringUnits;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Offers;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Products;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Request;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Roles;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Suppliers;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Application.Concrete.AutoMapper
{
    public class RequestModelToDomain : Profile
    {
        public RequestModelToDomain()
        {
            CreateMap<CreateCompanyRM, Company>();
            CreateMap<UpdateCompanyRM, Company>();
            CreateMap<DeleteCompanyRM, Company>();
            CreateMap<GetCompanyByIdRM, Company>();

            CreateMap<CreateCompanyDepartmanRM, CompanyDepartment>();
            CreateMap<DeleteCompanyDepartmentRM, CompanyDepartment>();
            CreateMap<UpdateCompanyDepartmentRM, CompanyDepartment>();
            CreateMap<GetDepartmentByCompanyIdRM, CompanyDepartment>();
            CreateMap<GetCompanyDepartmentByIdRM, CompanyDepartment>();

            CreateMap<GetByIdDepartmentRM, Department>();
            CreateMap<CreateDepartmentRM, Department>();
            CreateMap<UpdateDepartmentRM, Department>();

            CreateMap<CreateRoleRM, Role>();
            CreateMap<UpdateRoleRM, Role>();
            CreateMap<GetRoleByIdRM, Role>();
            CreateMap<GetRoleByNameRM, Role>();

            CreateMap<CreateProductRM, Product>();
            CreateMap<UpdateProductRM, Product>();

            CreateMap<CreateEmployeeRoleRM, EmployeeRole>();
            CreateMap<UpdateEmployeeRoleRM, EmployeeRole>();
            CreateMap<GetByEmployeeIdRM, EmployeeRole>();
            CreateMap<GetByRoleIdRM, EmployeeRole>();
            CreateMap<GetEmployeeRoleByIdRM, EmployeeRole>();

            CreateMap<CreateEmployeeVM, Employee>();
            CreateMap<CreateEmployeeVM, EmployeeDetail>();
            CreateMap<UpdateEmployeeVM,EmployeeDetail>();

            CreateMap<CreateCompanyStockRM, CompanyStock>();
            CreateMap<UpdateCompanyStockRM, CompanyStock>();
            CreateMap<UpdateCompanyQuantityAddRM, CompanyStock>(); // adet güncelleme

            CreateMap<CreateMeasuringUnitRM, MeasuringUnit>();
            CreateMap<UpdateMeasuringUnitRM, MeasuringUnit>();

            CreateMap<CreateCurrencyRM, Currency>();
            CreateMap<UpdateCurrencyRM, Currency>();

            CreateMap<CreateRequestRM, Request>();
            CreateMap<UpdateRequestStateRM, Request>();
            CreateMap<UpdateRequestRM, Request>();

            CreateMap<CreateSupplierRM,  Supplier>();
            CreateMap<UpdateSupplierRM, Supplier>();
            CreateMap<GetSupplierByIdRM, Supplier>();

            CreateMap<CreateInvoiceRM, Invoice>();
            CreateMap<UpdateInvoiceRM, Invoice>();
            CreateMap<GetInvoiceByIdRM, Invoice>();

            CreateMap<CreateOfferRM, Offer>();
            CreateMap<UpdateOfferRM, Offer>();
            CreateMap<UpdateOfferStateRM, Offer>();


            CreateMap<StockOperationsDto, StockOperations>();

            CreateMap<UpdateInvoiceStatusRM, Invoice>();
        }
    }
}
