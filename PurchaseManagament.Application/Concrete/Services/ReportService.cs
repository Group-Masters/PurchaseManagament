using AutoMapper;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Report;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Domain.Enums;
using PurchaseManagament.Persistence.Abstract.UnitWork;

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
            var requestEntity = await _uWork.GetRepository<Request>().GetByFilterAsync(x => x.RequestEmployeeId == getByIdVM.Id,
                 "Product.MeasuringUnit", "RequestEmployee.CompanyDepartment.Department", "RequestEmployee.CompanyDepartment.Company", "ApprovedEmployee", "Offers.Supplier", "Offers.Currency","Offers.Invoice");
            var requestMapping = _mapper.Map<HashSet<ReportDto>>(requestEntity);
            result.Data = requestMapping;
            return result;

        }
        public async Task<Result<HashSet<ReportDto>>> GetReportByDepartmentId(GetReportDepartmentVM getByIdVM)
        {
            var result = new Result<HashSet<ReportDto>>();
            var requestEntity = await _uWork.GetRepository<Request>().GetByFilterAsync(x => x.RequestEmployee.CompanyDepartment.CompanyId == getByIdVM.CompanyId && x.RequestEmployee.CompanyDepartment.DepartmentId==getByIdVM.DepartmentId,
                "Product.MeasuringUnit", "RequestEmployee.CompanyDepartment.Department", "RequestEmployee.CompanyDepartment.Company", "ApprovedEmployee", "Offers.Supplier", "Offers.Invoice", "Offers.Currency");
            var requestMapping = _mapper.Map<HashSet<ReportDto>>(requestEntity);
            result.Data = requestMapping;
            return result;

        }
        public async Task<Result<HashSet<ReportDto>>> GetReportByCompanyId(GetByIdVM getByIdVM)
        {


            var result = new Result<HashSet<ReportDto>>();
            var requestEntity = await _uWork.GetRepository<Request>().GetByFilterAsync(x => x.RequestEmployee.CompanyDepartment.CompanyId == getByIdVM.Id,
                "Product.MeasuringUnit", "RequestEmployee.CompanyDepartment.Department", "RequestEmployee.CompanyDepartment.Company", "ApprovedEmployee", "Offers.Supplier", "Offers.Invoice", "Offers.Currency");
            var requestMapping = _mapper.Map<HashSet<ReportDto>>(requestEntity);
            result.Data = requestMapping;
            return result;

        }

        public async Task<Result<HashSet<ReportDto>>> GetProductReport(GetReportProductVM getByIdVM)
        {
            var result = new Result<HashSet<ReportDto>>();
            var requestEntity = await _uWork.GetRepository<Request>().GetByFilterAsync(x => x.Product.Id == getByIdVM.ProductId && x.RequestEmployee.CompanyDepartment.CompanyId == getByIdVM.CompanyId,
                "Product.MeasuringUnit", "RequestEmployee.CompanyDepartment.Department", "RequestEmployee.CompanyDepartment.Company", "ApprovedEmployee", "Offers.Supplier", "Offers.Currency", "Offers.Invoice");
            var requestMapping = _mapper.Map<HashSet<ReportDto>>(requestEntity);
            result.Data = requestMapping;
            return result;
        }
        public async Task<Result<HashSet<ReportSupplierDto>>> GetSupplierReport(GetReportSupplierVM getByIdVM)
        {
            var result = new Result<HashSet<ReportSupplierDto>>();
            var offerEntity = await _uWork.GetRepository<Offer>().GetByFilterAsync(x => x.Supplier.Id == getByIdVM.SupplierId && x.Request.RequestEmployee.CompanyDepartment.CompanyId==getByIdVM.CompanyId,"Request.Product.MeasuringUnit", "Currency", "Supplier");
            var dtos = _mapper.Map<HashSet<ReportSupplierDto>>(offerEntity);
            result.Data = dtos;
            return result;


        }

        public async Task<Result<RequestReportDto>> GetRequestReportbyRequestId(GetByIdVM getByIdVM )
        {
            var result = new Result<RequestReportDto>();
            var requestEntity = await _uWork.GetRepository<Request>().GetSingleByFilterAsync(x => x.Id == getByIdVM.Id,
                "Product.MeasuringUnit", "RequestEmployee.CompanyDepartment.Department", "RequestEmployee.CompanyDepartment.Company", "ApprovedEmployee", "Offers.Supplier", "Offers.Invoice", "Offers.Currency");
            var requestMapping = _mapper.Map<RequestReportDto>(requestEntity);
            var offerMapping = _mapper.Map<List<OfferReportDto>>(requestEntity.Offers);
            requestMapping.Offers=(offerMapping);
            result.Data = requestMapping;
            return result;
        }
    }
}
