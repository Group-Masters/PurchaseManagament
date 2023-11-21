using AutoMapper;
using KingAOP;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Attributes;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Companies;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Validators.Companies;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Application.Exceptions;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Persistence.Abstract.UnitWork;
using System.Dynamic;
using System.Linq.Expressions;

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

        [Validator(typeof(CreateCompanyValidator))]
        public async Task<Result<bool>> CreateCompany(CreateCompanyRM createCompanyRM)
        {
            var result = new Result<bool>();

            var mappedEntity = _mapper.Map<Company>(createCompanyRM);
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

        [Validator(typeof(GetCompanyValidator))]
        public async Task<Result<CompanyDto>> GetCompanyById(GetCompanyByIdRM getCompanyByIdRM)
        {
            var result = new Result<CompanyDto>();

            var existEntity = await _unitWork.GetRepository<Company>().GetById(getCompanyByIdRM.Id);
            var mappedEntity = _mapper.Map<CompanyDto>(existEntity);

            result.Data = mappedEntity;
            return result;
        }

        [Validator(typeof(UpdateCompanyValidator))]
        public async Task<Result<bool>> UpdateCompany(UpdateCompanyRM updateCompanyRM)
        {
            var result = new Result<bool>();

            var entity = await _unitWork.GetRepository<Company>().GetById(updateCompanyRM.Id);
            var mappedEntity = _mapper.Map(updateCompanyRM, entity);
            _unitWork.GetRepository<Company>().Update(mappedEntity);

            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        [Validator(typeof(DeleteCompanyValidator))]
        public async Task<Result<bool>> DeleteCompany(GetByIdVM id)
        {
            var result = new Result<bool>();

            var entity = await _unitWork.GetRepository<Company>().GetById(id.Id);
            entity.IsDeleted = true;
            _unitWork.GetRepository<Company>().Update(entity);

            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        [Validator(typeof(DeleteCompanyValidator))]
        public async Task<Result<bool>> DeleteCompanyPermanent(GetByIdVM id)
        {
            var result = new Result<bool>();

            var entity = await _unitWork.GetRepository<Company>().GetById(id.Id);
            _unitWork.GetRepository<Company>().Delete(entity);

            result.Data = await _unitWork.CommitAsync();
            return result;
        }
    }
}
