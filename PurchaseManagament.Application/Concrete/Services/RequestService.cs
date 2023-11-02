using AutoMapper;
using Microsoft.AspNetCore.Components;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Request;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Domain.Abstract;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Persistence.Abstract.UnitWork;

namespace PurchaseManagament.Application.Concrete.Services
{
    [Route("request")]
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

        public async Task<Result<long>> UpdateRequest(UpdateRequestRM updateRequestRM)
        {
            var result = new Result<long>();
            var entity = await _unitWork.GetRepository<Request>().GetById(updateRequestRM.Id);
            if (entity is null)
            {
                throw new Exception("Talep güncellemesi için id eşleşmesi başarısız oldu.");
            }
            var mappedEntity = _mapper.Map(updateRequestRM, entity);
            _unitWork.GetRepository<Request>().Update(mappedEntity);
            await _unitWork.CommitAsync();
            result.Data = entity.Id;
            return result;
        }

        public async Task<Result<long>> UpdateRequestState(UpdateRequestStateRM updateRequestStateRM)
        {
            var result = new Result<long>();
            var entity = await _unitWork.GetRepository<Request>().GetById(updateRequestStateRM.Id);
            if (entity is null)
            {
                throw new Exception("Talep güncellemesi için id eşleşmesi başarısız oldu.");
            }
            var mappedEntity = _mapper.Map(updateRequestStateRM, entity);
            _unitWork.GetRepository<Request>().Update(mappedEntity);
            await _unitWork.CommitAsync();
            result.Data = entity.Id;
            return result;
        }
        public async Task<Result<bool>> DeleteRequest(long id)
        {
            var result = new Result<bool>();
            var entity = await _unitWork.GetRepository<Request>().GetById(id);
            if (entity is null)
            {
                throw new Exception("Böyle id ye sahip Talep bulunamamıştır.");
            }
            entity.IsDeleted = true;
            _unitWork.GetRepository<Request>().Update(entity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        public async Task<Result<bool>> DeleteRequestPermanent(long id)
        {
            var result = new Result<bool>();
            var entity = _unitWork.GetRepository<Request>().GetById(id);
            if (entity is null)
            {
                throw new Exception("Böyle id ye sahip Talep bulunamamıştır.");
            }
            _unitWork.GetRepository<Request>().Delete(await entity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        public async Task<Result<HashSet<RequestDto>>> GetAllRequest()
        {
            var result = new Result<HashSet<RequestDto>>();
            var entities = await _unitWork.GetRepository<Request>().GetAllAsync("Product", "ApprovedEmployee", "RequestEmployee");
            var mappedEntity = _mapper.Map<HashSet<RequestDto>>(entities);
            result.Data = mappedEntity;
            return result;
        }

        public async Task<Result<RequestDto>> GetRequestById(GetRequestByIdRM getRequestById)
        {
            var result = new Result<RequestDto>();
            var entityControl = await _unitWork.GetRepository<Request>().AnyAsync(x => x.Id == getRequestById.Id);
            if (!entityControl)
            {
                throw new Exception($"{getRequestById.Id}'li talep bulunamamıştır.");
            }

            var existEntity = await _unitWork.GetRepository<Request>().GetSingleByFilterAsync(x => x.Id == getRequestById.Id, "Product", "ApprovedEmployee", "RequestEmployee");
            var mappedEntity = _mapper.Map<RequestDto>(existEntity);
            result.Data = mappedEntity;
            return result;
        }
    }
}
