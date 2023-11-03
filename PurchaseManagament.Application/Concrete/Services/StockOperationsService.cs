using AutoMapper;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyStocks;
using PurchaseManagament.Application.Concrete.Models.RequestModels.MeasuringUnits;
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



        public async Task CreateStockOperations(UpdateCompanyQuantityRM updateCompanyQuantityRM)
        {

            // Company Stok Id & Product Id
            var companyStock = await _unitWork.GetRepository<CompanyStock>().GetSingleByFilterAsync(q => q.Id == updateCompanyQuantityRM.Id);

            StockOperationsDto stockOperationsDto = new StockOperationsDto()
            {
                CompanyStockId = companyStock.Id,
                ProductId = companyStock.ProductId,
                Quantity = updateCompanyQuantityRM.Quantity,
                Notification = updateCompanyQuantityRM.Quantity.ToString() + " Adet Stoktan tedarik edildi",
                //ReceiverEmployeeId = 1

                ReceiverEmployeeId = updateCompanyQuantityRM.ReceiverEmployeeId

            };

            StockOperations stockOperations = new StockOperations();
            _mapper.Map(stockOperationsDto, stockOperations);


            _unitWork.GetRepository<StockOperations>().Add(stockOperations);



            //var result = new Result<long>();
            //var mappedEntity = _mapper.Map<MeasuringUnit>(createMeasuringUnitRM);
            //_unitWork.GetRepository<MeasuringUnit>().Add(mappedEntity);
            //await _unitWork.CommitAsync();
            //result.Data = mappedEntity.Id;
            //return result;
        }

        public Task<Result<HashSet<StockOperationsDto>>> GetAllStockOperations()
        {
            throw new NotImplementedException();
        }
    }
}
