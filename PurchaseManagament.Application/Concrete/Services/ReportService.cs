using AutoMapper;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Persistence.Abstract.UnitWork;
using PurchaseManagament.Persistence.Concrete.UnitWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Concrete.Services
{
    public class ReportService : IReportService
    {
        private readonly IUnitWork _uWork;
        private readonly IMapper _mapper;

        public ReportService(IUnitWork uWork, IMapper mapper)
        {
            _uWork = uWork;
            _mapper = mapper;
        }

        public async Task<Result<HashSet<ReportDto>>> GetReportByEmployeeId(GetByIdVM getByIdVM)
        {
            var result = new Result<HashSet<ReportDto>>();
            var entities = await _uWork.GetRepository<Offer>().GetByFilterAsync(x => x.Request.RequestEmployee.Id == getByIdVM.Id && x.Status==Domain.Enums.Status.Tamamlandı
            , "Currency", "Supplier", "ApprovingEmployee.CompanyDepartment.Company", "Request.Product.MeasuringUnit", "Request.RequestEmployee.CompanyDepartment.Company","Invoice");
            var mappedEntity = _mapper.Map<HashSet<ReportDto>>(entities);
            result.Data = mappedEntity;
            return result;

        }

    }
}
