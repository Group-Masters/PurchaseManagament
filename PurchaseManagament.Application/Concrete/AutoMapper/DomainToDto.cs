using AutoMapper;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Application.Concrete.AutoMapper
{
    public class DomainToDto : Profile
    {
        public DomainToDto()
        {
            CreateMap<Company, CompanyDto>();
            CreateMap<CompanyDepartment, CompanyDepartmentDto>();
            CreateMap<CompanyStock, CompanyStocksDto>();

            CreateMap<Product, ProductDto>()
                .ForMember(x=>x.MeasuringName,y=>y.MapFrom(z=>z.MeasuringUnit.Name));

            CreateMap<MeasuringUnit, MeasuringUnitDto>();

            CreateMap<Department, DepartmentDto>();

            CreateMap<Employee, EmployeeDto>()
                .ForMember(x => x.Email, y => y.MapFrom(z => z.EmployeeDetail.Email))
                .ForMember(x => x.Phone, y => y.MapFrom(z => z.EmployeeDetail.Phone))
                .ForMember(x => x.Address, y => y.MapFrom(z => z.EmployeeDetail.Address))
                .ForMember(x => x.DepartmentName, y => y.MapFrom(z => z.CompanyDepartment.Department.Name))
                .ForMember(x => x.Roles, y => y.MapFrom(z => z.EmployeeRoles.Select(x=>x.Role).Select(x => x.Name).ToList()));


           
            CreateMap<EmployeeRole, EmployeeRoleDto>();
            CreateMap<EmployeeRole, EmployeeRoleDetailDto>()
                .ForMember(x => x.EmployeeName, y => y.MapFrom(z => z.Employee.Name))
                .ForMember(x => x.EmployeeSurname, y => y.MapFrom(z => z.Employee.Surname))
                .ForMember(x => x.EmployeeEmail, y => y.MapFrom(z => z.Employee.EmployeeDetail.Email))
                .ForMember(x => x.RoleName, y => y.MapFrom(z => z.Role.Name));

            CreateMap<Role, RoleDto>();

            CreateMap<Currency, CurrencyDTO>();

            CreateMap<Request, RequestDTO>();

            CreateMap<Supplier, SupplierDto>();

            CreateMap<Invoice, InvoiceDto>();

            CreateMap<Offer, OfferDto>();

            CreateMap<StockOperations,StockOperationsDTO>();
        }
    }
}
