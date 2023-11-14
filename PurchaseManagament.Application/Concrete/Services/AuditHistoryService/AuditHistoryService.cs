using AutoMapper;
using PurchaseManagament.Application.Abstract.Service.AuditHistoryService;
using PurchaseManagament.Application.Concrete.Models.Dtos.AuditHistory;
using PurchaseManagament.Application.Concrete.Models.RequestModels.AuditHistory;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Domain.Entities.Audits;
using PurchaseManagament.Persistence.Abstract.UnitWork;

namespace PurchaseManagament.Application.Concrete.Services.AuditHistoryService
{
    public class AuditHistoryService : IAuditHistoryService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;


        public AuditHistoryService(IMapper mapper, IUnitWork unitWork)
        {
            _mapper = mapper;
            _unitWork = unitWork;
        }

        public async Task<Result<AuditHistoryDto>> GetAuditHistoryById(GetByIdAuditRM getByIdAuditRM)
        {
            var result = new Result<AuditHistoryDto>();

            var entityExist = await _unitWork.GetRepository<Audit>().GetSingleByFilterAsync(x => x.Id == getByIdAuditRM.Id, "AuditMetaData", "Employee");
            var mappedEntity = _mapper.Map<AuditHistoryDto>(entityExist);

            result.Data = mappedEntity;
            return result;
        }

        public async Task<Result<HashSet<AuditSmallDto>>> GetAuditsByUserId(GetAuditsByUserIdRM getAuditsByUserIdRM)
        {
            var result = new Result<HashSet<AuditSmallDto>>();

            var entityExist = await _unitWork.GetRepository<Audit>().GetByFilterAsync(x => x.UserId == getAuditsByUserIdRM.UserId, "AuditMetaData", "Employee");
            var mappedEntity = _mapper.Map<HashSet<AuditSmallDto>>(entityExist);

            result.Data = mappedEntity;
            return result;
        }

        public async Task<Result<HashSet<AuditHistoryDto>>> GetAuditsByDisplayName(GetAuditsByDislpayNameRM getAuditsByDislpayName)
        {
            var result = new Result<HashSet<AuditHistoryDto>>();

            var entityExist = await _unitWork.GetRepository<Audit>().GetByFilterAsync(x => x.MetaDisplayName == getAuditsByDislpayName.MetaDisplayName, "AuditMetaData", "Employee");
            var mappedEntity = _mapper.Map<HashSet<AuditHistoryDto>>(entityExist);

            result.Data = mappedEntity;
            return result;
        }

        public async Task<Result<HashSet<AuditHistoryDto>>> GetAuditsByCompanyDisplay(GetAuditsByCompanyDisplayRM getAuditsByCompanyDisplayRM)
        {
            var result = new Result<HashSet<AuditHistoryDto>>();

            var entityExist = await _unitWork.GetRepository<Audit>().GetByFilterAsync(x => x.MetaDisplayName == getAuditsByCompanyDisplayRM.MetaDisplayName && 
                x.Employee.CompanyDepartment.CompanyId == getAuditsByCompanyDisplayRM.CompanyId, "AuditMetaData", "Employee");
            var mappedEntity = _mapper.Map<HashSet<AuditHistoryDto>>(entityExist);

            result.Data = mappedEntity;
            return result;
        }

        public async Task<Result<HashSet<AuditHistoryDto>>> GetAuditsSpecified(GetAuditsSpecifiedRM getAuditsSpecifiedRM)
        {
            var result = new Result<HashSet<AuditHistoryDto>>();

            var entityExist = await _unitWork.GetRepository<Audit>().GetByFilterAsync(x => x.MetaDisplayName == getAuditsSpecifiedRM.MetaDisplayName &&
                x.AuditMetaData.ReadablePrimaryKey == getAuditsSpecifiedRM.ReadablePrimaryKey, "AuditMetaData", "Employee");

            var mappedEntity = _mapper.Map<HashSet<AuditHistoryDto>>(entityExist);

            result.Data = mappedEntity;
            return result;
        }

        public async Task<Result<HashSet<AuditHistoryDto>>> GetAuditsByCompany(GetAuditsByCompanyIdRM getAuditsByCompanyId)
        {
            var result = new Result<HashSet<AuditHistoryDto>>();

            var entityExists = await _unitWork.GetRepository<Audit>().GetByFilterAsync(x => x.Employee.CompanyDepartment.CompanyId == getAuditsByCompanyId.CompanyId, "AuditMetaData", "Employee");

            var mappedEntity = _mapper.Map<HashSet<AuditHistoryDto>>(entityExists); 
            
            result.Data = mappedEntity; 
            return result;
        }

        public async Task<Result<HashSet<AuditHistoryDto>>> GetAllAuditHistory()
        {
            var result = new Result<HashSet<AuditHistoryDto>>();

            var entityExist = await _unitWork.GetRepository<Audit>().GetAllAsync("AuditMetaData", "Employee");
            var mappedEntity = _mapper.Map<HashSet<AuditHistoryDto>>(entityExist);

            result.Data = mappedEntity;
            return result;
        }
    }
}
