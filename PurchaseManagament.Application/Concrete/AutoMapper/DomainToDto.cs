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
            CreateMap<CompanyDepartment, CompanyDepartmentDto>()
                .ForMember(x => x.CompanyName, y => y.MapFrom(z => z.Company.Name))
                .ForMember(x => x.DepartmentName, y => y.MapFrom(z => z.Department.Name));

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
               // .ForMember(x => x.Roles, y => y.MapFrom(z => z.EmployeeRoles.Select(x=>x.Role).Select(x => x.Name).ToList()));
               .ForMember(x => x.Username, y => y.MapFrom(z => z.EmployeeDetail.Username));



            CreateMap<EmployeeRole, EmployeeRoleDto>();
            CreateMap<EmployeeRole, EmployeeRoleDetailDto>()
                .ForMember(x => x.EmployeeName, y => y.MapFrom(z => z.Employee.Name))
                .ForMember(x => x.EmployeeSurname, y => y.MapFrom(z => z.Employee.Surname))
                .ForMember(x => x.EmployeeEmail, y => y.MapFrom(z => z.Employee.EmployeeDetail.Email))
                .ForMember(x => x.RoleName, y => y.MapFrom(z => z.Role.Name));

            CreateMap<Role, RoleDto>();

            CreateMap<Currency, CurrencyDTO>();

            CreateMap<Request, RequestDto>()
                .ForMember(x => x.ProductName, y => y.MapFrom(z => z.Product.Name))
                .ForMember(x => x.ApprovingEmployeeName, y => y.MapFrom(z => z.ApprovedEmployee.Name))
                .ForMember(x => x.ApprovingEmployeeSurname, y => y.MapFrom(z => z.ApprovedEmployee.Surname))
                .ForMember(x => x.RequestEmployeeName, y => y.MapFrom(z => z.RequestEmployee.Name))
                .ForMember(x => x.RequestEmployeeSurname, y => y.MapFrom(z => z.RequestEmployee.Surname))
                .ForMember(x => x.MeasuringUnitName, y => y.MapFrom(z => z.Product.MeasuringUnit.Name));
                

            CreateMap<Supplier, SupplierDto>();

            CreateMap<Invoice, InvoiceDto>()
                .ForMember(x => x.CompanyName, y => y.MapFrom(z => z.Offer.Request.RequestEmployee.CompanyDepartment.Company.Name))
                .ForMember(x => x.CompanyAddress, y => y.MapFrom(z => z.Offer.Request.RequestEmployee.CompanyDepartment.Company.Adress))
                .ForMember(x => x.SupplierName, y => y.MapFrom(z => z.Offer.Supplier.Name))
                .ForMember(x => x.SupplierAddress, y => y.MapFrom(z => z.Offer.Supplier.Address))
                .ForMember(x => x.ProductName, y => y.MapFrom(z => z.Offer.Request.Product.Name))
                .ForMember(x => x.Quantity, y => y.MapFrom(z => z.Offer.Request.Quantity))
                .ForMember(x => x.MeasuringUnit, y => y.MapFrom(z => z.Offer.Request.Product.MeasuringUnit))
                .ForMember(x => x.OfferedPrice, y => y.MapFrom(z => z.Offer.OfferedPrice));


            CreateMap<Offer, OfferDto>()
                .ForMember(x => x.CurrencyName, y => y.MapFrom(z => z.Currency.Name))
                .ForMember(x => x.SupplierName, y => y.MapFrom(z => z.Supplier.Name))
                .ForMember(x => x.ApprovingEmployeeName, y => y.MapFrom(z => z.ApprovingEmployee.Name))
                .ForMember(x => x.ApprovingEmployeeSurname, y => y.MapFrom(z => z.ApprovingEmployee.Surname))
                .ForMember(x => x.ProductName, y => y.MapFrom(x => x.Request.Product.Name))
                .ForMember(x => x.Quantity, y => y.MapFrom(x => x.Request.Quantity))
                .ForMember(x => x.MeasuringUnit, y => y.MapFrom(x => x.Request.Product.MeasuringUnit));


            CreateMap<StockOperations, StockOperationsDto>();
        }
    }
}
