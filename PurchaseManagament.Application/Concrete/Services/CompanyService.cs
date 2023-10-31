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

        public async Task<Result<bool>> DeleteCompany(DeleteCompanyRM deleteCompanyRM)
        {
            var result = new Result<bool>();
            var existEntity = await _unitWork.GetRepository<Company>().AnyAsync(x => x.Id == deleteCompanyRM.Id);
            if (!existEntity)
            {
                throw new Exception("Böyle bir ıd silinmek için bulunamadı.");
            }
            var entity = await _unitWork.GetRepository<Company>().GetById(deleteCompanyRM.Id);
            _unitWork.GetRepository<Company>().Delete(entity);
            result.Data = await _unitWork.CommitAsync();
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

        public async Task<Result<CompanyDto>> GetCompanyByName(string companyName)
        {
            var result = new Result<CompanyDto>();
            var existEntity = await _unitWork.GetRepository<Company>().AnyAsync(x => x.Name.ToUpper().Trim() == companyName.ToUpper().Trim());
            if (existEntity)
            {
                throw new Exception("Bu isimle bir şirket bulunamadı.");
            }
            var entity = await _unitWork.GetRepository<Company>().GetByFilterAsync(x => x.Name.ToUpper().Trim() == companyName.ToUpper().Trim());
            var mappedEntity = _mapper.Map<CompanyDto>(entity);
            result.Data = mappedEntity;
            return result;

        }

        public async Task<Result<bool>> UpdateCompany(UpdateCompanyRM updateCompanyRM)
        {
            var result = new Result<bool>();
            var existEntity = await _unitWork.GetRepository<Company>().AnyAsync(x => x.Id == updateCompanyRM.Id);
            if (existEntity)
            {
                throw new Exception("Bu id ye sahip bir şirket bulunamadı.");
            }
            var entity = await _unitWork.GetRepository<Company>().GetById(updateCompanyRM.Id);
            var mappedEntity = _mapper.Map(updateCompanyRM, entity);
            _unitWork.GetRepository<Company>().Update(mappedEntity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }
    }
}
