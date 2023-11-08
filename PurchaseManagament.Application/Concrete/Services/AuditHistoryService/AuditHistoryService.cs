using AutoMapper;
using PurchaseManagament.Application.Abstract.Service.AuditHistoryService;
using PurchaseManagament.Application.Concrete.Models.Dtos.AuditHistory;
using PurchaseManagament.Application.Concrete.Models.RequestModels.AuditHistory;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Domain.Entities.Audits;
using PurchaseManagament.Persistence.Abstract.UnitWork;
using System.Text.RegularExpressions;

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

        public async Task<Result<AuditHistoryDto>> GetAuditById(GetByIdAuditRM getByIdAuditRM)
        {
            var result = new Result<AuditHistoryDto>();

            var entityExist = await _unitWork.GetRepository<Audit>().GetSingleByFilterAsync(x => x.Id == getByIdAuditRM.Id, "AuditMetaData");
            var mappedEntity = _mapper.Map<AuditHistoryDto>(entityExist);

            result.Data = mappedEntity;
            return result;
        }

        public async Task<Result<HashSet<AuditSmallDto>>> GetAuditsByEmployeeId(GetByIdVM getByIdVM)
        {
            var result = new Result<HashSet<AuditSmallDto>>();
            string UserId = $"{getByIdVM.Id}";

            var entityExist = await _unitWork.GetRepository<Audit>().GetByFilterAsync(x => x.UserId == UserId);
            var mappedEntity = _mapper.Map<HashSet<AuditSmallDto>>(entityExist);

            result.Data = mappedEntity;
            return result;
        }

        public async Task<Result<HashSet<AuditHistoryDto>>> GetAuditsByTable(GetAuditsByTableRM getAuditsByOperationRM)
        {
            var result = new Result<HashSet<AuditHistoryDto>>();

            var entityExist = await _unitWork.GetRepository<Audit>().GetByFilterAsync(x => x.AuditMetaData.Table ==  getAuditsByOperationRM.Table, "AuditMetaData");
            var mappedEntity = _mapper.Map<HashSet<AuditHistoryDto>>(entityExist);

            result.Data = mappedEntity;
            return result;
        }

        //Not Implemented Yet
        public async Task<Result<HashSet<AuditHistoryDto>>> GetAuditsSpecified(GetAuditsSpecifiedRM getAuditsSpecifiedRM)
        {
            var result = new Result<HashSet<AuditHistoryDto>>();
            Regex ExtractedId = new Regex("^[0-9]+$");
            var extracted = long.Parse(ExtractedId.Matches($"{getAuditsSpecifiedRM.ReadablePrimaryKey}").ToString());

            Type type = Type.GetType(getAuditsSpecifiedRM.Table);

            if (type != null)
            {
                object instance = Activator.CreateInstance(type);
                // Now you have an instance of your class
            }
            else
            {
                Console.WriteLine($"Class {getAuditsSpecifiedRM.Table} not found");
            }


            //var entityExist = await _unitWork.GetRepository<Audit>().GetByFilterAsync();
            throw new NotImplementedException();
        }

        public async Task<Result<HashSet<AuditHistoryDto>>> GetAllAuditHistory()
        {
            var result = new Result<HashSet<AuditHistoryDto>>();

            var entityExist = await _unitWork.GetRepository<Audit>().GetAllAsync();
            var mappedEntity = _mapper.Map<HashSet<AuditHistoryDto>>(entityExist);

            result.Data = mappedEntity;
            return result;
        }
    }
}
