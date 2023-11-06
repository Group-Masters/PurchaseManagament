using AutoMapper;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Attributes;
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

        [Validator(typeof(CreateCompanyRM))]
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

        public async Task<Result<CompanyDto>> GetCompanyById(GetCompanyByIdRM getCompanyByIdRM)
        {
            var result = new Result<CompanyDto>();
            var entityControl = await _unitWork.GetRepository<Company>().AnyAsync(x => x.Id == getCompanyByIdRM.Id);
            if (!entityControl)
            {
                throw new Exception($"Şirket ID {getCompanyByIdRM.Id} bulunamadı.");
            }

            var existEntity = await _unitWork.GetRepository<Company>().GetById(getCompanyByIdRM.Id);
            var mappedEntity = _mapper.Map<CompanyDto>(existEntity);
            result.Data = mappedEntity;
            return result;
        }

        public async Task<Result<bool>> UpdateCompany(UpdateCompanyRM updateCompanyRM)
        {
            var result = new Result<bool>();
            var existEntity = await _unitWork.GetRepository<Company>().AnyAsync(x => x.Id == updateCompanyRM.Id);
            if (!existEntity)
            {
                throw new Exception("Bu id ye sahip bir şirket bulunamadı.");
            }
            var entity = await _unitWork.GetRepository<Company>().GetById(updateCompanyRM.Id);
            var mappedEntity = _mapper.Map(updateCompanyRM, entity);
            _unitWork.GetRepository<Company>().Update(mappedEntity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        public async Task<Result<bool>> DeleteCompany(Int64 id)
        {
            var result = new Result<bool>();
            var existEntity = await _unitWork.GetRepository<Company>().AnyAsync(x => x.Id == id);
            if (!existEntity)
            {
                throw new Exception("Böyle bir ıd silinmek için bulunamadı.");
            }
            var entity = await _unitWork.GetRepository<Company>().GetById(id);
            entity.IsDeleted = true;
            _unitWork.GetRepository<Company>().Update(entity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        public async Task<Result<bool>> DeleteCompanyPermanent(Int64 id)
        {
            var result = new Result<bool>();
            var existEntity = await _unitWork.GetRepository<Company>().AnyAsync(x => x.Id == id);
            if (!existEntity)
            {
                throw new Exception("Böyle bir ıd silinmek için bulunamadı.");
            }
            var entity = await _unitWork.GetRepository<Company>().GetById(id);
            _unitWork.GetRepository<Company>().Delete(entity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }
    }
}
