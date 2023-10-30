using AutoMapper;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Companies;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Persistence.Abstract.UnitWork;

namespace PurchaseManagament.Application.Concrete.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;

        public CompanyService(IMapper mapper, IUnitWork unitWork)
        {
            _mapper = mapper;
            _unitWork = unitWork;
        }

        public async Task<Result<bool>> CreateCompany(CreateCompanyRM createCompanyRM)
        {
            var result = new Result<bool>();
            var mappedEntity = _mapper.Map<Company>(createCompanyRM);
            var existEntity = await _unitWork.GetRepository<Company>().AnyAsync(z => z.Name == mappedEntity.Name);
            if (existEntity)
            {
                throw new Exception("Böyle bir şirket ismi zaten mevcut.");
            }
            _unitWork.GetRepository<Company>().Add(mappedEntity);
            var resultBool = await _unitWork.CommitAsync();
            result.Data = resultBool;
            return result;
        }

        public async Task<Result<HashSet<CompanyDto>>> GetAllCompany()
        {
            var result = new Result<HashSet<CompanyDto>>();
            var entities = await _unitWork.GetRepository<Company>().GetAllAsync();
            var mappedEntity = _mapper.Map<HashSet<CompanyDto>>(entities);
            result.Data = mappedEntity;
            return result;
        }
    }
}
