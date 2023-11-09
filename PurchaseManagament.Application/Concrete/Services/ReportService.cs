using AutoMapper;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Report;
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
            , "Currency", "Supplier", "ApprovingEmployee.CompanyDepartment.Company", "Request.Product.MeasuringUnit", "Request.RequestEmployee.CompanyDepartment.Company", "Request.RequestEmployee.CompanyDepartment.Department", "Invoice");
            var mappedEntity = _mapper.Map<HashSet<ReportDto>>(entities);
            var requestEntity = await _uWork.GetRepository<Request>().GetByFilterAsync(x => x.RequestEmployee.Id == getByIdVM.Id ,
                "Product.MeasuringUnit", "RequestEmployee.CompanyDepartment.Department", "RequestEmployee.CompanyDepartment.Company", "ApprovedEmployee", "Offers.Supplier", "Offers.Invoice");// "Product.MeasuringUnit", "RequestEmployee.CompanyDepartment.Company", 
                                                                                                                                                                                               // "RequestEmployee.CompanyDepartment.Department");


            var requestMapping = _mapper.Map<HashSet<ReportDto>>(requestEntity);

            var dtos = mappedEntity.Union(requestMapping).ToHashSet();

            result.Data = dtos;
            return result;

        }
        public async Task<Result<HashSet<ReportDto>>> GetReportByDepartmentId(GetByIdVM getByIdVM)
        {
            var result = new Result<HashSet<ReportDto>>();
            var entities = await _uWork.GetRepository<Offer>().GetByFilterAsync(x => x.Request.RequestEmployee.CompanyDepartmentId == getByIdVM.Id && x.Status == Domain.Enums.Status.Tamamlandı
            , "Currency", "Supplier", "ApprovingEmployee.CompanyDepartment.Company", "Request.Product.MeasuringUnit", "Request.RequestEmployee.CompanyDepartment.Company", "Request.RequestEmployee.CompanyDepartment.Department", "Invoice");
            var mappedEntity = _mapper.Map<HashSet<ReportDto>>(entities);
            var requestEntity = await _uWork.GetRepository<Request>().GetByFilterAsync(x => x.RequestEmployee.CompanyDepartmentId == getByIdVM.Id && x.State != Domain.Enums.Status.Tamamlandı,
                "Product.MeasuringUnit", "RequestEmployee.CompanyDepartment.Department", "RequestEmployee.CompanyDepartment.Company", "ApprovedEmployee", "Offers.Supplier", "Offers.Invoice");// "Product.MeasuringUnit", "RequestEmployee.CompanyDepartment.Company", 
                                                                                                                                                                                               // "RequestEmployee.CompanyDepartment.Department");


            var requestMapping = _mapper.Map<HashSet<ReportDto>>(requestEntity);

            var dtos = mappedEntity.Union(requestMapping).ToHashSet();

            result.Data = dtos;
            return result;

        }
        public async Task<Result<HashSet<ReportDto>>> GetReportByCompanyId(GetByIdVM getByIdVM)
        {
            var result = new Result<HashSet<ReportDto>>();
            
            var requestEntity = await _uWork.GetRepository<Request>().GetByFilterAsync(x => x.RequestEmployee.CompanyDepartment.CompanyId == getByIdVM.Id && x.State != Domain.Enums.Status.Tamamlandı,
                "Product.MeasuringUnit", "RequestEmployee.CompanyDepartment.Department", "RequestEmployee.CompanyDepartment.Company", "ApprovedEmployee", "Offers.Supplier", "Offers.Invoice");// "Product.MeasuringUnit", "RequestEmployee.CompanyDepartment.Company", 
            var requestMapping = _mapper.Map<HashSet<ReportDto>>(requestEntity);
            result.Data = requestMapping;
            return result;
             #region güncellenmemiş
           // var result = new Result<HashSet<ReportDto>>();
           // //var entities = await _uWork.GetRepository<Offer>().GetByFilterAsync(x => x.Request.RequestEmployee.CompanyDepartment.CompanyId == getByIdVM.Id && x.Status == Domain.Enums.Status.Tamamlandı
           // //, "Currency", "Supplier", "ApprovingEmployee.CompanyDepartment.Company", "Request.Product.MeasuringUnit", "Request.RequestEmployee.CompanyDepartment.Company", "Request.RequestEmployee.CompanyDepartment.Department", "Invoice");
           //// var mappedEntity = _mapper.Map<HashSet<ReportDto>>(entities);
           // var requestEntity = await _uWork.GetRepository<Request>().GetByFilterAsync(x => x.RequestEmployee.CompanyDepartment.CompanyId == getByIdVM.Id && x.State != Domain.Enums.Status.Tamamlandı,
           //     "Product.MeasuringUnit", "RequestEmployee.CompanyDepartment.Department", "RequestEmployee.CompanyDepartment.Company", "ApprovedEmployee", "Offers.Supplier", "Offers.Invoice");// "Product.MeasuringUnit", "RequestEmployee.CompanyDepartment.Company", 
           //     // "RequestEmployee.CompanyDepartment.Department");


           // var requestMapping = _mapper.Map<HashSet<ReportDto>>(requestEntity);

           ////var dtos= mappedEntity.Union(requestMapping).ToHashSet();
            
           // result.Data = requestMapping;
           // return result;
            #endregion
        }

        public async Task<Result<HashSet<ReportDto>>> GetProductReport(GetReportProductVM getByIdVM)
        {
            var result = new Result<HashSet<ReportDto>>();
            var entities = await _uWork.GetRepository<Offer>().GetByFilterAsync(x => x.Request.Product.Id == getByIdVM.ProductId && x.Request.RequestEmployee.CompanyDepartment.Company.Id==getByIdVM.CompanyId && x.Status == Domain.Enums.Status.Tamamlandı
            , "Currency", "Supplier", "ApprovingEmployee.CompanyDepartment.Company", "Request.Product.MeasuringUnit", "Request.RequestEmployee.CompanyDepartment.Company", "Request.RequestEmployee.CompanyDepartment.Department", "Invoice");
            var mappedEntity = _mapper.Map<HashSet<ReportDto>>(entities);

            var requestEntity = await _uWork.GetRepository<Request>().GetByFilterAsync(x => x.Product.Id == getByIdVM.ProductId && x.RequestEmployee.CompanyDepartment.Company.Id == getByIdVM.CompanyId && x.State != Domain.Enums.Status.Tamamlandı,
                "Product.MeasuringUnit", "RequestEmployee.CompanyDepartment.Department", "RequestEmployee.CompanyDepartment.Company", "ApprovedEmployee", "Offers.Supplier", "Offers.Invoice");// "Product.MeasuringUnit", "RequestEmployee.CompanyDepartment.Company", 
                // "RequestEmployee.CompanyDepartment.Department");


            var requestMapping = _mapper.Map< HashSet<ReportDto>>(requestEntity);

           var dtos= mappedEntity.Union(requestMapping).ToHashSet();




            result.Data = dtos;
            return result;
        }
        public async Task<Result<HashSet<ReportSupplierDto>>> GetSupplierReport(GetByIdVM getByIdVM)
        {
            var result= new Result<HashSet<ReportSupplierDto>>();
            var offerEntity= await _uWork.GetRepository<Offer>().GetByFilterAsync(x => x.Supplier.Id == getByIdVM.Id, "Request.Product.MeasuringUnit", "Currency","Supplier");
          var dtos=  _mapper.Map<HashSet<ReportSupplierDto>>(offerEntity);
            result.Data = dtos;
            return result;


        }
    }
}
