using AutoMapper;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Persistence.Abstract.UnitWork;

namespace PurchaseManagament.Application.Concrete.Services
{
    public class StockOperationsService : IStockOperationsService
    {
        private readonly IUnitWork _unitWork;
        private readonly IMapper _mapper;
        public StockOperationsService(IUnitWork unitWork, IMapper mapper)
        {
            _unitWork = unitWork;
            _mapper = mapper;
        }

        public async Task<Result<HashSet<StockOperationsDto>>> GetAllStockOperations()
        {
            var result = new Result<HashSet<StockOperationsDto>>();

            var entities = await _unitWork.GetRepository<StockOperationsDto>().GetAllAsync("CompanyStock.Product.MeasuringUnit", "Employee");
            var mappedEntities = _mapper.Map<HashSet<StockOperationsDto>>(entities);

            result.Data = mappedEntities;
            return result;
        }

        public async Task<Result<HashSet<StockOperationsDto>>> GetStockOperationsByDepartmentId(GetByIdVM getByIdVM)
        {
            var result = new Result<HashSet<StockOperationsDto>>();

            var entities = await _unitWork.GetRepository<StockOperations>().GetByFilterAsync(x => x.Employee.CompanyDepartment.DepartmentId == getByIdVM.Id, "CompanyStock.Product.MeasuringUnit", "Employee");
            var mappedEntities = _mapper.Map<HashSet<StockOperationsDto>>(entities);

            result.Data = mappedEntities;
            return result;
        }

        public async Task<Result<HashSet<StockOperationsDto>>> GetStockOperationsByCompanyId(GetByIdVM getByIdVM)
        {
            var result = new Result<HashSet<StockOperationsDto>>();

            var entities = await _unitWork.GetRepository<StockOperations>().GetByFilterAsync(x => x.Employee.CompanyDepartment.CompanyId == getByIdVM.Id, "CompanyStock.Product.MeasuringUnit", "Employee");
            var mappedEntities = _mapper.Map<HashSet<StockOperationsDto>>(entities);

            result.Data = mappedEntities;
            return result;
        }

        public async Task<Result<HashSet<StockOperationsDto>>> GetStockOperationsByEmployeeId(GetByIdVM getByIdVM)
        {
            var result = new Result<HashSet<StockOperationsDto>>();

            var entities = await _unitWork.GetRepository<StockOperations>().GetByFilterAsync(x => x.ReceivingEmployeeId == getByIdVM.Id, "CompanyStock.Product.MeasuringUnit", "Employee");
            var mappedEntities = _mapper.Map<HashSet<StockOperationsDto>>(entities);

            result.Data = mappedEntities;
            return result;
        }
    }
}
