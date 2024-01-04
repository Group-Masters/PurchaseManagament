using AutoMapper;
using Microsoft.AspNetCore.Components;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Attributes;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Request;
using PurchaseManagament.Application.Concrete.Validators.Request;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Application.Exceptions;
using PurchaseManagament.Domain.Abstract;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Domain.Enums;
using PurchaseManagament.Persistence.Abstract.UnitWork;
using PurchaseManagament.Utils;

namespace PurchaseManagament.Application.Concrete.Services
{
    [NullCheckParam]
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
            if (entity is null)
            {
                throw new NotFoundException("Güncellenmek istenen Talep kaydı bulunamadı.");
            }
            var mappedEntity = _mapper.Map(updateRequestRM, entity);
            _unitWork.GetRepository<Request>().Update(mappedEntity);
            await _unitWork.CommitAsync();
            result.Data = entity.Id;
            return result;
        }

        [Validator(typeof(UpdateRequestStateValidator))]
        public async Task<Result<long>> UpdateRequestState(UpdateRequestStateRM updateRequestStateRM)
        {
            var result = new Result<long>();
            var entity = await _unitWork.GetRepository<Request>().GetSingleByFilterAsync(x=>x.Id==updateRequestStateRM.Id, "Product.MeasuringUnit", "RequestEmployee.EmployeeDetail");
            if (entity is null)
            {
                throw new NotFoundException("Durumu güncellenmek istenen Talep kaydı bulunamadı.");
            }
            if (updateRequestStateRM.State==Status.Onay|| updateRequestStateRM.State == Status.Reddedildi)
            {
                entity.ApprovingEmployeeId = _loggedService.UserId;
                entity.ApprovedDate = DateTime.Now;
                if (updateRequestStateRM.State == Status.Reddedildi)
                {
                    SenderUtils.SendMail(entity.RequestEmployee.EmployeeDetail.Email, "Talep Bilgilendirme", $"Oluşturmuş olduğunuz {entity.Id} numaralı {entity.Quantity} {entity.Product.MeasuringUnit.Name} {entity.Product.Name} talebiniz Birim Müdürü tarafınca reddetilmiştir.");
                }
            }
            var mappedEntity = _mapper.Map(updateRequestStateRM, entity);
            _unitWork.GetRepository<Request>().Update(mappedEntity);
            await _unitWork.CommitAsync();
            result.Data = entity.Id;
            return result;
        }

        [Validator(typeof(GetByIdValidator))]
        public async Task<Result<bool>> DeleteRequest(GetByIdVM id)
        {
            var result = new Result<bool>();
            var entity = await _unitWork.GetRepository<Request>().GetById(id.Id);
            if (entity is null)
            {
                throw new NotFoundException("Silinmek istenen Talep kaydı bulunamadı.");
            }
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
            if (entity is null)
            {
                throw new NotFoundException("Silinmek istenen Talep kaydı bulunamadı.");
            }
            _unitWork.GetRepository<Request>().Delete(await entity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        public async Task<Result<HashSet<RequestDto>>> GetAllRequest()
        {
            var result = new Result<HashSet<RequestDto>>();
            var entities = await _unitWork.GetRepository<Request>().GetAllAsync("Product.MeasuringUnit", "ApprovedEmployee", "RequestEmployee");
            var mappedEntity = _mapper.Map<HashSet<RequestDto>>(entities);
            result.Data = mappedEntity;
            return result;
        }

        [Validator(typeof(GetRequestByIdValidator))]
        public async Task<Result<RequestDto>> GetRequestById(GetRequestByIdRM getRequestById)
        {
            var result = new Result<RequestDto>();
            var entityControl = await _unitWork.GetRepository<Request>().AnyAsync(x => x.Id == getRequestById.Id);
            if (!entityControl)
            {
                throw new NotFoundException("İstenen Talep kaydı bulunamadı.");
            }

            var existEntity = await _unitWork.GetRepository<Request>().GetSingleByFilterAsync(x => x.Id == getRequestById.Id, "Product.MeasuringUnit", "ApprovedEmployee", "RequestEmployee");
            var mappedEntity = _mapper.Map<RequestDto>(existEntity);
            result.Data = mappedEntity;
            return result;
        }

        //[Validator(typeof(GetRequestByIdValidator))] Validasyon Yazılacak
        public async Task<Result<HashSet<RequestDto>>> GetRequestByIdentity(GetByIdentityVM getIdentity)
        {
            var result = new Result<HashSet<RequestDto>>();
            var entityControl = await _unitWork.GetRepository<Request>().AnyAsync(x => x.RequestEmployee.IdNumber == getIdentity.IdentityNumber);
            if (!entityControl)
            {
                throw new NotFoundException("İstenen Talep kaydı bulunamadı.");
            }

            var existEntity = await _unitWork.GetRepository<Request>().GetByFilterAsync(x => x.RequestEmployee.IdNumber == getIdentity.IdentityNumber, "Product.MeasuringUnit", "ApprovedEmployee", "RequestEmployee");
            var mappedEntity = _mapper.Map<HashSet<RequestDto>>(existEntity);
            result.Data = mappedEntity;
            return result;
        }

        [Validator(typeof(GetRequestByEmployeeIdValidator))]
        public async Task<Result<HashSet<RequestDto>>> GetRequestByEmployeeId(GetRequestByEmployeeIdRM getRequestByEmployeeIdRM)
        {
            var result = new Result<HashSet<RequestDto>>();
            var entityControl = await _unitWork.GetRepository<Request>().AnyAsync(x => x.RequestEmployeeId ==  getRequestByEmployeeIdRM.RequestEmployeeId);
            if (!entityControl)
            {
                throw new NotFoundException("İstenen Çalışana ait Talep kaydı bulunamadı.");
            }

            var existsEntity = await _unitWork.GetRepository<Request>().GetByFilterAsync(x => x.RequestEmployeeId == getRequestByEmployeeIdRM.RequestEmployeeId, "Product.MeasuringUnit", "ApprovedEmployee", "RequestEmployee");
            var mappedEntity = _mapper.Map<HashSet<RequestDto>>(existsEntity);
            result.Data = mappedEntity;
            return result;
        }

        [Validator(typeof(GetRequestByCIdDIdValidator))]
        public async Task<Result<HashSet<RequestDto>>> GetRequestByCIdDId(GetRequestByCIdDIdRM getRequestByCIdDIdRM)
        {
            var result = new Result<HashSet<RequestDto>>();
            var companyDepartmentControl = await _unitWork.GetRepository<CompanyDepartment>().AnyAsync(x => x.CompanyId == getRequestByCIdDIdRM.CompanyId && x.DepartmentId == getRequestByCIdDIdRM.DepartmentId);
            if (!companyDepartmentControl)
            {
                throw new NotFoundException("İstenen Şirket/Departman'a ait Talep kaydı bulunamadı.");
            }

            var companyDepartment = await _unitWork.GetRepository<CompanyDepartment>().GetSingleByFilterAsync(x => x.CompanyId == getRequestByCIdDIdRM.CompanyId && x.DepartmentId == getRequestByCIdDIdRM.DepartmentId);

            var requestFilter = await _unitWork.GetRepository<Request>().GetByFilterAsync(x => x.RequestEmployee.CompanyDepartmentId == companyDepartment.Id, "Product.MeasuringUnit", "ApprovedEmployee", "RequestEmployee");
            var mappedEntity = _mapper.Map<HashSet<RequestDto>>(requestFilter);
            result.Data = mappedEntity;
            return result;
        }

        [Validator(typeof(GetRequestByCIdDIdValidator))]
        public async Task<Result<HashSet<RequestDto>>> GetPendingRequestByCIdDId(GetRequestByCIdDIdRM getRequestByCIdDIdRM)
        {
            var result = new Result<HashSet<RequestDto>>();
            var companyDepartmentControl = await _unitWork.GetRepository<CompanyDepartment>().AnyAsync(x => x.CompanyId == getRequestByCIdDIdRM.CompanyId && x.DepartmentId == getRequestByCIdDIdRM.DepartmentId);
            if (!companyDepartmentControl)
            {
                throw new NotFoundException("İstenen Şirket/Departman'a ait Bekleyen Talep kaydı bulunamadı.");
            }

            var companyDepartment = await _unitWork.GetRepository<CompanyDepartment>().GetSingleByFilterAsync(x => x.CompanyId == getRequestByCIdDIdRM.CompanyId && x.DepartmentId == getRequestByCIdDIdRM.DepartmentId);

            var requestFilter = await _unitWork.GetRepository<Request>().GetByFilterAsync(x => x.RequestEmployee.CompanyDepartmentId == companyDepartment.Id && x.State== Status.Beklemede, "Product.MeasuringUnit", "ApprovedEmployee", "RequestEmployee");
            var mappedEntity = _mapper.Map<HashSet<RequestDto>>(requestFilter);
            result.Data = mappedEntity;
            return result;
        }

        [Validator(typeof(GetByIdValidator))]
        public async Task<Result<HashSet<RequestDto>>> GetRequesApprovedtByCompany(GetByIdVM getByIdVM)
        {
            var result = new Result<HashSet<RequestDto>>();
            var entity = await _unitWork.GetRepository<Request>().GetByFilterAsync(x => x.RequestEmployee.CompanyDepartment.CompanyId == getByIdVM.Id && x.State == Status.Onay, "Product.MeasuringUnit", "ApprovedEmployee", "RequestEmployee.CompanyDepartment", "Product.MeasuringUnit");

            var dtos = _mapper.Map<HashSet<RequestDto>>(entity);
            result.Data = dtos;
            return result;          
        }
    }
}
