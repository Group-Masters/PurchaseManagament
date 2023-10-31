using AutoMapper;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Companies;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyDepartments;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Departments;
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


            CreateMap<CreateCompanyDepartmentRM, Company>();
            CreateMap<DeleteCompanyDepartmentRM, Company>();
            CreateMap<UpdateCompanyDepartmentRM, Company>();

            CreateMap<DeleteDepartmentRM, Department>();
            CreateMap<CreateDepartmentRM, Department>();
            CreateMap<UpdateDepartmentRM, Department>();


        }
    }
}
