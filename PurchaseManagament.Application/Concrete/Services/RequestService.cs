using AutoMapper;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Attributes;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Request;
using PurchaseManagament.Application.Concrete.Validators.Request;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Domain.Abstract;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Domain.Enums;
using PurchaseManagament.Persistence.Abstract.UnitWork;

namespace PurchaseManagament.Application.Concrete.Services
{
    [NullCheckParam]
    public class RequestService : IRequestService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;
        private readonly ILoggedService _loggedService;
        private readonly IMaterialService _materialService;

        public RequestService(IUnitWork unitWork, IMapper mapper, ILoggedService loggedService, IMaterialService materialService)
        {
            _unitWork = unitWork;
            _mapper = mapper;
            _loggedService = loggedService;
            _materialService = materialService;
        }

        #region CRUD Operations
        [Validator(typeof(CreateRequestValidator))]
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

        [Validator(typeof(UpdateRequestValidator))]
        public async Task<Result<long>> UpdateRequest(UpdateRequestRM updateRequestRM)
        {
            var result = new Result<long>();

            var entity = await _unitWork.GetRepository<Request>().GetById(updateRequestRM.Id);
            var mappedEntity = _mapper.Map(updateRequestRM, entity);
            _unitWork.GetRepository<Request>().Update(mappedEntity);

            await _unitWork.CommitAsync();
            result.Data = entity.Id;
            return result;
        }

        /// <summary>
        /// Talep Durumunu dinamik olarak Günceller.
        /// </summary>
        /// <param name="getByIdVM">Request Id'sini alır.</param>
        /// <returns>Güncellenen Talebi döner.</returns>
        [Validator(typeof(UpdateRequestStateValidator))]
        public async Task<Result<Request>> RequestStatusUpdate(GetByIdVM getByIdVM)
        {
            var result = new Result<Request>();

            int completedMaterials = 0;
            int pendingMaterials = 0;
            int declinedMaterials = 0;

            //İstenen talebe ait Ürünlerin listesini alıp Durumlarını kontrol eder.
            var requestMaterials = await _unitWork.GetRepository<Material>().GetByFilterAsync(x => x.RequestId == getByIdVM.Id);
            foreach (var offerMaterial in requestMaterials)
            {
                if (offerMaterial.State == Status.Tamamlandı)
                {
                    completedMaterials++;
                }
                else if (offerMaterial.State == Status.Reddedildi)
                {
                    declinedMaterials++;
                }
                else if (offerMaterial.State == Status.Beklemede)
                {
                    pendingMaterials++;
                }
            }

            //Talebe ait Ürünlerin durumlarını analiz eder ve Talebin durumunu günceller.
            var request = await _unitWork.GetRepository<Request>().GetById(getByIdVM.Id);
            if (pendingMaterials == requestMaterials.ToList().Count)
            {
                request.State = Status.Beklemede;
            }
            else if ((completedMaterials + declinedMaterials) == requestMaterials.ToList().Count)
            {
                request.State = Status.Tamamlandı;
            }
            else
            {
                request.State = Status.İşlemeAlindi;
            }
            _unitWork.GetRepository<Request>().Update(request);

            await _unitWork.CommitAsync();
            result.Data = request;
            return result;
        }

        [Validator(typeof(GetByIdValidator))]
        public async Task<Result<bool>> DeleteRequest(GetByIdVM id)
        {
            var result = new Result<bool>();

            var entity = await _unitWork.GetRepository<Request>().GetById(id.Id);
            entity.IsDeleted = true;
            _unitWork.GetRepository<Request>().Update(entity);

            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        [Validator(typeof(GetByIdValidator))]
        public async Task<Result<bool>> DeleteRequestPermanent(GetByIdVM id)
        {
            var result = new Result<bool>();

            var entity = _unitWork.GetRepository<Request>().GetById(id.Id);
            _unitWork.GetRepository<Request>().Delete(await entity);

            result.Data = await _unitWork.CommitAsync();
            return result;
        }
        #endregion


        #region Get Operations

        public async Task<Result<HashSet<RequestDto>>> GetAllRequest()
        {
            var result = new Result<HashSet<RequestDto>>();

            var entities = await _unitWork.GetRepository<Request>().GetAllAsync("RequestEmployee");
            var mappedEntity = _mapper.Map<HashSet<RequestDto>>(entities);

            result.Data = mappedEntity;
            return result;
        }

        [Validator(typeof(GetRequestByIdValidator))]
        public async Task<Result<RequestDto>> GetRequestById(GetRequestByIdRM getRequestById)
        {
            var result = new Result<RequestDto>();

            var entityControl = await _unitWork.GetRepository<Request>().AnyAsync(x => x.Id == getRequestById.Id);
            var existEntity = await _unitWork.GetRepository<Request>().GetSingleByFilterAsync(x => x.Id == getRequestById.Id, "RequestEmployee");
            var mappedEntity = _mapper.Map<RequestDto>(existEntity);

            result.Data = mappedEntity;
            return result;
        }

        [Validator(typeof(GetRequestByEmployeeIdValidator))]
        public async Task<Result<HashSet<RequestDto>>> GetRequestByEmployeeId(GetRequestByEmployeeIdRM getRequestByEmployeeIdRM)
        {
            var result = new Result<HashSet<RequestDto>>();

            var entityControl = await _unitWork.GetRepository<Request>().AnyAsync(x => x.RequestEmployeeId == getRequestByEmployeeIdRM.RequestEmployeeId);
            var existsEntity = await _unitWork.GetRepository<Request>().GetByFilterAsync(x => x.RequestEmployeeId == getRequestByEmployeeIdRM.RequestEmployeeId, "RequestEmployee");
            var mappedEntity = _mapper.Map<HashSet<RequestDto>>(existsEntity);

            result.Data = mappedEntity;
            return result;
        }

        [Validator(typeof(GetRequestByCIdDIdValidator))]
        public async Task<Result<HashSet<RequestDto>>> GetRequestByCIdDId(GetRequestByCIdDIdRM getRequestByCIdDIdRM)
        {
            var result = new Result<HashSet<RequestDto>>();

            var companyDepartment = await _unitWork.GetRepository<CompanyDepartment>().GetSingleByFilterAsync(x => x.CompanyId == getRequestByCIdDIdRM.CompanyId && x.DepartmentId == getRequestByCIdDIdRM.DepartmentId);
            var requestFilter = await _unitWork.GetRepository<Request>().GetByFilterAsync(x => x.RequestEmployee.CompanyDepartmentId == companyDepartment.Id, "RequestEmployee");
            var mappedEntity = _mapper.Map<HashSet<RequestDto>>(requestFilter);

            result.Data = mappedEntity;
            return result;
        }

        [Validator(typeof(GetRequestByCIdDIdValidator))]
        public async Task<Result<HashSet<RequestDto>>> GetPendingRequestByCIdDId(GetRequestByCIdDIdRM getRequestByCIdDIdRM)
        {
            var result = new Result<HashSet<RequestDto>>();

            var companyDepartment = await _unitWork.GetRepository<CompanyDepartment>().GetSingleByFilterAsync(x => x.CompanyId == getRequestByCIdDIdRM.CompanyId && x.DepartmentId == getRequestByCIdDIdRM.DepartmentId);
            var requestFilter = await _unitWork.GetRepository<Request>().GetByFilterAsync(x => x.RequestEmployee.CompanyDepartmentId == companyDepartment.Id && x.State == Status.Beklemede, "RequestEmployee");
            var mappedEntity = _mapper.Map<HashSet<RequestDto>>(requestFilter);

            result.Data = mappedEntity;
            return result;
        }

        [Validator(typeof(GetByIdValidator))]
        public async Task<Result<HashSet<RequestDto>>> GetRequesApprovedtByCompany(GetByIdVM getByIdVM)
        {
            var result = new Result<HashSet<RequestDto>>();

            var entity = await _unitWork.GetRepository<Request>().GetByFilterAsync(x => x.RequestEmployee.CompanyDepartment.CompanyId == getByIdVM.Id && x.State == Status.Onay, "RequestEmployee.CompanyDepartment");
            var dtos = _mapper.Map<HashSet<RequestDto>>(entity);

            result.Data = dtos;
            return result;
        }
        #endregion
    }
}
