using AutoMapper;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Products;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Request;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Domain.Abstract;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Persistence.Abstract.UnitWork;

namespace PurchaseManagament.Application.Concrete.Services
{
    public class RequestService : IRequestService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;
        private readonly ILoggedService _loggedService;

        public RequestService(IUnitWork unitWork, IMapper mapper, ILoggedService loggedService)
        {
            _unitWork = unitWork;
            _mapper = mapper;
            _loggedService = loggedService;
        }

        public async Task<Result<long>> CreateRequest(CreateRequestRM createRequestRM)
        {
            var result = new Result<long>();
            var mappedEntity = _mapper.Map<Request>(createRequestRM);
            mappedEntity.RequestEmployeeId = (Int64)_loggedService.UserId;
            _unitWork.GetRepository<Request>().Add(mappedEntity);
            await _unitWork.CommitAsync();
            result.Data = mappedEntity.Id;
            return result;
        }

        public Task<Result<bool>> DeleteRequest(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> DeleteRequestPermanent(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<HashSet<ProductDto>>> GetAllProduct()
        {
            throw new NotImplementedException();
        }

        public Task<Result<long>> UpdateRequest(UpdateRequestRM updateRequestRM)
        {
            throw new NotImplementedException();
        }

        public Task<Result<long>> UpdateRequestState(UpdateRequestStateRM updateRequestStateRM)
        {
            throw new NotImplementedException();
        }
    }
}
