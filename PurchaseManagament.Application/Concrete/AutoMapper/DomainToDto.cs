﻿using AutoMapper;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Domain.Enums;

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

            CreateMap<CompanyStock, CompanyStocksDto>()
                .ForMember(x => x.ProductName, y => y.MapFrom(z => z.Product.Name))
                .ForMember(x => x.MeasuringUnitName, y => y.MapFrom(z => z.Product.MeasuringUnit.Name));

            CreateMap<Product, ProductDto>()
                .ForMember(x => x.MeasuringName, y => y.MapFrom(z => z.MeasuringUnit.Name))
                .ForMember(x => x.ImgProduct, y => y.MapFrom(z => z.ImgProduct.ImageSrc));

            CreateMap<MeasuringUnit, MeasuringUnitDto>();

            CreateMap<Department, DepartmentDto>();

            CreateMap<Employee, EmployeeDto>()
                .ForMember(x => x.Email, y => y.MapFrom(z => z.EmployeeDetail.Email))
                .ForMember(x => x.Phone, y => y.MapFrom(z => z.EmployeeDetail.Phone))
                .ForMember(x => x.Address, y => y.MapFrom(z => z.EmployeeDetail.Address))
                .ForMember(x => x.DepartmentName, y => y.MapFrom(z => z.CompanyDepartment.Department.Name))
                .ForMember(x => x.Roles, y => y.MapFrom(z => z.EmployeeRoles.Select(x => x.Role.Name).ToList()))
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
                .ForMember(x => x.RequestEmployeeName, y => y.MapFrom(z => z.RequestEmployee.Name))
                .ForMember(x => x.RequestEmployeeSurname, y => y.MapFrom(z => z.RequestEmployee.Surname));

            CreateMap<Material, MaterialDto>()
                .ForMember(x => x.ProductName, y => y.MapFrom(z => z.Product.Name))
                .ForMember(x => x.MeasuringUnit, y => y.MapFrom(z => z.Product.MeasuringUnit.Name));

            CreateMap<MaterialOffer, MaterialOfferDto>()
                .ForMember(x => x.SupplierName, y => y.MapFrom(z => z.Offer.Supplier.Name))
                .ForMember(x => x.ProductName, y => y.MapFrom(z => z.Material.Product.Name))
                .ForMember(x => x.Quantity, y => y.MapFrom(z => z.Material.Quantity))
                .ForMember(x => x.MeasuringUnit, y => y.MapFrom(z => z.Material.Product.MeasuringUnit.Name))
                .ForMember(x => x.Currency, y => y.MapFrom(z => z.Offer.Currency.Name));

            CreateMap<Supplier, SupplierDto>();

            CreateMap<Invoice, InvoiceDto>()
                .ForMember(x => x.CompanyName, y => y.MapFrom(z => z.Offer.ApprovingEmployee.CompanyDepartment.Company.Name))
                .ForMember(x => x.CompanyAddress, y => y.MapFrom(z => z.Offer.ApprovingEmployee.CompanyDepartment.Company.Address))
                .ForMember(x => x.SupplierName, y => y.MapFrom(z => z.Offer.Supplier.Name))
                .ForMember(x => x.SupplierAddress, y => y.MapFrom(z => z.Offer.Supplier.Address))
                .ForMember(x => x.Currency, y => y.MapFrom(z => z.Offer.Currency.Name));

            CreateMap<Offer, OfferDto>()
                .ForMember(x => x.CurrencyName, y => y.MapFrom(z => z.Currency.Name))
                .ForMember(x => x.SupplierName, y => y.MapFrom(z => z.Supplier.Name))
                .ForMember(x => x.ApprovingEmployeeName, y => y.MapFrom(z => z.ApprovingEmployee.Name))
                .ForMember(x => x.ApprovingEmployeeSurname, y => y.MapFrom(z => z.ApprovingEmployee.Surname))
                .ForMember(x => x.CompanyName, y => y.MapFrom(x => x.ApprovingEmployee.CompanyDepartment.Company.Name))
                .ForMember(x => x.CompanyAddress, y => y.MapFrom(x => x.ApprovingEmployee.CompanyDepartment.Company.Address))
                .ForMember(x => x.SupplierAddress, y => y.MapFrom(x => x.Supplier.Address));

            //CreateMap<Offer, ReportDto>()
            //    .ForMember(x => x.RequestId, y => y.MapFrom(z => z.Request.Id))
            //    .ForMember(x => x.Status, y => y.MapFrom(z => z.Request.State))
            //    .ForMember(x => x.Requestby, y => y.MapFrom(z => $"{z.Request.RequestEmployee.Name} {z.Request.RequestEmployee.Surname}"))
            //    .ForMember(x => x.Companydepartment, y => y.MapFrom(z => $"{z.Request.RequestEmployee.CompanyDepartment.Company.Name}- {z.Request.RequestEmployee.CompanyDepartment.Department.Name}"))
            //    .ForMember(x => x.product, y => y.MapFrom(x => $"{x.Request.Product.Name}-{x.Request.Product.MeasuringUnit.Name}"))
            //    .ForMember(x => x.Quantity, y => y.MapFrom(x => x.Request.Quantity))
            //    .ForMember(x => x.CreateDate, y => y.MapFrom(x => x.Request.CreatedDate.Value.ToString("yyyy-MM-dd")))
            //    .ForMember(x => x.ApprovedEmployee, y => y.MapFrom(z => $"{z.Request.ApprovedEmployee.Name} {z.Request.ApprovedEmployee.Surname}"))
            //    .ForMember(x => x.Prices, y => y.MapFrom(x => $"{x.OfferedPrice} {x.Currency.Name}"))
            //    .ForMember(x => x.supplier, y => y.MapFrom(x => x.Supplier.Name))
            //    .ForMember(x => x.supplyDate, y => y.MapFrom(x => x.Invoice.CreatedDate.Value.ToString("yyyy-MM-dd")))
            //.ForMember(x => x.InvoiceId, y => y.MapFrom(x => x.Invoice.Id));
            //CreateMap<Request, ReportDto>()
            //     .ForMember(x => x.RequestId, y => y.MapFrom(z => z.Id))
            //    .ForMember(x => x.Status, y => y.MapFrom(z => z.State))
            //    .ForMember(x => x.Requestby, y => y.MapFrom(z => $"{z.RequestEmployee.Name} {z.RequestEmployee.Surname}"))
            //    .ForMember(x => x.Companydepartment, y => y.MapFrom(z => $"{z.RequestEmployee.CompanyDepartment.Company.Name}- {z.RequestEmployee.CompanyDepartment.Department.Name}"))
            //    .ForMember(x => x.product, y => y.MapFrom(x => $"{x.Product.Name}-{x.Product.MeasuringUnit.Name}"))
            //    .ForMember(x => x.Quantity, y => y.MapFrom(x => x.Quantity))
            //    .ForMember(x => x.CreateDate, y => y.MapFrom(x => x.CreatedDate.Value.ToString("yyyy-MM-dd HH:mm")))
            //    .ForMember(x => x.ApprovedEmployee, y => y.MapFrom(z => z.ApprovedEmployee != null ? $"{z.ApprovedEmployee.Name} {z.ApprovedEmployee.Surname}" : " Beklemede"))
            //    .ForMember(x => x.Prices, y => y.MapFrom(x => x.Offers.SingleOrDefault(y => y.Status != Status.Beklemede && y.Status != Status.Reddedildi) != null ?
            //      $"{x.Offers.SingleOrDefault(y => y.Status != Status.Beklemede && y.Status != Status.Reddedildi).OfferedPrice}-{x.Offers.SingleOrDefault(y => y.Status != Status.Beklemede && y.Status != Status.Reddedildi).Currency.Name}" : "----"))
            //    .ForMember(x => x.Prices_Try, y => y.MapFrom(x => GetPricesTry(x)))
            //    .ForMember(x => x.supplier, y => y.MapFrom(x => x.Offers.SingleOrDefault(y => y.Status != Status.Beklemede && y.Status != Status.Reddedildi).Supplier.Name))
            //    .ForMember(x => x.supplyDate, y => y.MapFrom(x => x.Offers.SingleOrDefault(y => y.Status != Status.Beklemede && y.Status != Status.Reddedildi).Invoice.CreatedDate.Value.ToString("yyyy-MM-dd HH:mm")))
            //    .ForMember(x => x.InvoiceId, y => y.MapFrom(x => x.Offers.SingleOrDefault(y => y.Status != Status.Beklemede && y.Status != Status.Reddedildi).Invoice.Id));
            //CreateMap<Offer, ReportSupplierDto>()
            //    .ForMember(x => x.OfferId, y => y.MapFrom(z => z.Id))
            //    .ForMember(x => x.CreateDate, y => y.MapFrom(z => z.CreatedDate.Value.ToString("yyyy-MM-dd HH:mm")))
            //    .ForMember(x => x.Status, y => y.MapFrom(z => z.Status))
            //    .ForMember(x => x.Detail, y => y.MapFrom(z => z.Details))
            //    .ForMember(x => x.Price, y => y.MapFrom(z => $"{z.OfferedPrice} {z.Currency.Name}"))
            //    .ForMember(x => x.Product, y => y.MapFrom(z => $"{z.Request.Product.Name} - {z.Request.Product.MeasuringUnit.Name}"))
            //    .ForMember(x => x.Quantity, y => y.MapFrom(z => z.Request.Quantity))
            //    .ForMember(x => x.SupplierName, y => y.MapFrom(z => z.Supplier.Name));
            CreateMap<StockOperations, StockOperationsDto>()
                .ForMember(x => x.ProductName, y => y.MapFrom(x => x.CompanyStock.Product.Name))
                .ForMember(x => x.ReceiverName, y => y.MapFrom(x => x.Employee.Name))
                .ForMember(x => x.MeasuringUnit, y => y.MapFrom(x => x.CompanyStock.Product.MeasuringUnit.Name))
                .ForMember(x => x.ReceiverSurname, y => y.MapFrom(x => x.Employee.Surname));
            CreateMap<ImgProduct, ImgProductDto>();
            //CreateMap<Request, RequestReportDto>()
            //   .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            //   .ForMember(x => x.Status, y => y.MapFrom(z => z.State))
            //   .ForMember(x => x.CompanyName, y => y.MapFrom(z => z.RequestEmployee.CompanyDepartment.Company.Name))
            //   .ForMember(x => x.DepartmentName, y => y.MapFrom(z => z.RequestEmployee.CompanyDepartment.Department.Name))
            //   .ForMember(x => x.RequestEmployee, y => y.MapFrom(z => $"{z.RequestEmployee.Name}- {z.RequestEmployee.Surname}"))
            //   .ForMember(x => x.RequestDate, y => y.MapFrom(x => x.CreatedDate.Value.ToString("yyyy-MM-dd HH:mm")))
            //   .ForMember(x => x.Product, y => y.MapFrom(x => $"{x.Product.Name}-{x.Product.MeasuringUnit.Name}"))
            //   .ForMember(x => x.Quantity, y => y.MapFrom(x => x.Quantity))
            //   .ForMember(x => x.RequestDetails, y => y.MapFrom(z => z.Details))
            //   .ForMember(x => x.RequestApproveBy, y => y.MapFrom(z => z.ApprovedEmployee != null ? $"{z.ApprovedEmployee.Name} {z.ApprovedEmployee.Surname}" : " ----"))
            //   .ForMember(x => x.RequestApproveDate, y => y.MapFrom(z => z.ApprovedDate != null ? z.ApprovedDate.Value.ToString("yyyy-MM-dd HH:mm") : " ----"))
            //   .ForMember(x => x.OfferCount, y => y.MapFrom(z => z.Offers.Count().ToString()))
            //   .ForMember(x => x.UUID, y => y.MapFrom(x => x.Offers.SingleOrDefault(y => y.Status != Status.Beklemede && y.Status != Status.Reddedildi).Invoice.UUID.ToString()))
            //   .ForMember(x => x.Prices, y => y.MapFrom(x => x.Offers.SingleOrDefault(y => y.Status != Status.Beklemede && y.Status != Status.Reddedildi) != null ?
            //      $"{x.Offers.SingleOrDefault(y => y.Status != Status.Beklemede && y.Status != Status.Reddedildi).OfferedPrice}-{x.Offers.SingleOrDefault(y => y.Status != Status.Beklemede && y.Status != Status.Reddedildi).Currency.Name}/ {GetPricesTry(x)}" : "----"))
            //   .ForMember(x => x.InvoiceCreateDate, y => y.MapFrom(x => x.Offers.SingleOrDefault(y => y.Status != Status.Beklemede && y.Status != Status.Reddedildi).Invoice.CreatedDate.Value.ToString("yyyy-MM-dd HH:mm")));
            //CreateMap<Offer, OfferReportDto>()
            //     .ForMember(x => x.offerId, y => y.MapFrom(z => z.Id))
            //     .ForMember(x => x.OfferPrice, y => y.MapFrom(z => $"{z.OfferedPrice} {z.Currency.Name}"))
            //     .ForMember(x => x.Supplier, y => y.MapFrom(z => z.Supplier.Name))
            //     .ForMember(x => x.OfferDetail, y => y.MapFrom(z => z.Details))
            //     .ForMember(x => x.CreateDate, y => y.MapFrom(z => z.CreatedDate.Value.ToString("yyyy-MM-dd HH:mm")))
            //     .ForMember(x => x.ApprovingBy, y => y.MapFrom(z => z.ApprovingEmployee != null ? $"{z.ApprovingEmployee.Name} {z.ApprovingEmployee.Surname}" : " Beklemede"))
            //     .ForMember(x => x.Status, y => y.MapFrom(z => z.Status));
            CreateMap<Employee, TokenDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.CompanyId, y => y.MapFrom(z => z.CompanyDepartment.CompanyId))
                .ForMember(x => x.DepartmentId, y => y.MapFrom(z => z.CompanyDepartment.DepartmentId))
                .ForMember(x => x.RolId, y => y.MapFrom(z => z.EmployeeRoles.Select(x => x.RoleId).ToList()));

        }
       

        //private string GetPricesTry(Request x)
        //{
        //    var offer = x.Offers.SingleOrDefault(y => y.Status != Status.Beklemede && y.Status != Status.Reddedildi);

        //    if (offer != null && offer.Invoice != null)
        //    {
        //        return $"{offer.Invoice.TRY_Rate}-{"TRY"}";
        //    }
        //    else
        //    {
        //        // Invoice veya offer null ise veya Invoice içinde TRY_Rate null ise bir varsayılan değer kullanabilirsiniz.
        //        return "----"; // Örnek bir varsayılan değer
        //    }
        //}

    }
}