using AutoMapper;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos.ChartDtos;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Domain.Enums;
using PurchaseManagament.Persistence.Abstract.UnitWork;

namespace PurchaseManagament.Application.Concrete.Services
{
    public class ChartService : IChartService
    {
        private readonly IUnitWork _uWork;
        private readonly IMapper _mapper;
        public ChartService(IUnitWork uWork, IMapper mapper)
        {
            _uWork = uWork;
            _mapper = mapper;
        }

        //public async Task<Result<List<ChartDto>>> GetChartCompany()
        //{
        //    var result=new Result<List<ChartDto>>();
        //    var entities= await _uWork.GetRepository<Company>().GetAllAsync("CompanyDepartments.Employees");
        //    throw new Exception();

        //}

        public async Task<Result<MainChartDto>> GetMainChart()
        {
            var result = new Result<MainChartDto>();

            var enties = await _uWork.GetRepository<Employee>().GetByFilterAsync(x => x.IsActive == true);
            var InvoiceEnties = await _uWork.GetRepository<Invoice>().GetAllAsync();
            var requestEntity = await _uWork.GetRepository<Request>().GetAllAsync();
            var companyentity = await _uWork.GetRepository<Company>().GetAllAsync();
     


            var mainChartDto = new MainChartDto
            {
                EmployeeCount = enties.ToList().LongCount(),
                TotalPrice = InvoiceEnties.ToList().Select(x=>x.TRY_Rate).Sum(),
                RequestCount = requestEntity.ToList().LongCount(),
                CompanyCount= companyentity.ToList().Count(),
            };
            result.Data=mainChartDto;


            return result;
        }
    }
}
