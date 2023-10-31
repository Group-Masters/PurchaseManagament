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
            CreateMap<Employee, EmployeeDto>()
                .ForMember(x=>x.Email,y=>y.MapFrom(z=>z.EmployeeDetail.Email))
                .ForMember(x=>x.Phone,y=>y.MapFrom(z=>z.EmployeeDetail.Phone));


        }
    }
}
