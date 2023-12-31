﻿using AutoMapper;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Attributes;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyDepartments;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Validators.CompanyDepartman;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Application.Exceptions;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Persistence.Abstract.UnitWork;

namespace PurchaseManagament.Application.Concrete.Services
{
    [NullCheckParam]
    public class CompanyDepartmentService : ICompanyDepartmentService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;

        public CompanyDepartmentService(IMapper mapper, IUnitWork unitWork)
        {
            _mapper = mapper;
            _unitWork = unitWork;
        }
        [Validator(typeof(CreateCompanyDepartmanValidator))]
        public async Task<Result<bool>> CreateCompanyDepartment(CreateCompanyDepartmanRM createCompanyDepartmentRM)
        {
            var result = new Result<bool>();

            var companyDepartmentExists = await _unitWork.GetRepository<CompanyDepartment>().AnyAsync
                (x => x.CompanyId == createCompanyDepartmentRM.CompanyId && x.DepartmentId == createCompanyDepartmentRM.DepartmentId);
            if (companyDepartmentExists)
            {
                throw new AlreadyExistsException("Bu Şirket/Departman kaydı zaten bulunmakta.");
            }

            var mappedEntity = _mapper.Map<CompanyDepartment>(createCompanyDepartmentRM);
            _unitWork.GetRepository<CompanyDepartment>().Add(mappedEntity);
            var resultBool = await _unitWork.CommitAsync();
            result.Data = resultBool;
            return result;
        }

        [Validator(typeof(UpdateCompanyDepartmanValidator))]
        public async Task<Result<bool>> UpdateCompanyDepartment(UpdateCompanyDepartmentRM updateCompanyDepartmentRM)
        {
            var result = new Result<bool>();
            var existEntity = await _unitWork.GetRepository<CompanyDepartment>().AnyAsync(x => x.DepartmentId == updateCompanyDepartmentRM.DepartmentId);
            if (!existEntity)
            {
                throw new NotFoundException("Güncellenmek istenen Şirket/Departman kaydı bulunamadı.");
            }
            var entity = await _unitWork.GetRepository<CompanyDepartment>().GetById(updateCompanyDepartmentRM.DepartmentId);
            var mappedEntity = _mapper.Map(updateCompanyDepartmentRM, entity);
            _unitWork.GetRepository<CompanyDepartment>().Update(mappedEntity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        [Validator(typeof(DeleteCompanyDepartmanValidator))]
        public async Task<Result<bool>> DeleteCompanyDepartment(GetByIdVM id)
        {
            var result = new Result<bool>();
            var existEntity = await _unitWork.GetRepository<CompanyDepartment>().AnyAsync(x => x.Id == id.Id);
            if (!existEntity)
            {
                throw new NotFoundException("Silinmek istenen Şirket/Departman kaydı bulunamadı.");
            }
            var entity = await _unitWork.GetRepository<CompanyDepartment>().GetById(id.Id);
            entity.IsDeleted = true;
            _unitWork.GetRepository<CompanyDepartment>().Update(entity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }        
        [Validator(typeof(DeleteCompanyDepartmanValidator))]
        public async Task<Result<bool>> DeleteCompanyDepartmentPermanent(GetByIdVM id)
        {
            var result = new Result<bool>();
            var existEntity = await _unitWork.GetRepository<CompanyDepartment>().AnyAsync(x => x.Id == id.Id);
            if (!existEntity)
            {
                throw new NotFoundException("Silinmek istenen Şirket/Departman kaydı bulunamadı.");
            }
            var entity = await _unitWork.GetRepository<CompanyDepartment>().GetById(id.Id);
            _unitWork.GetRepository<CompanyDepartment>().Delete(entity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }


        public async Task<Result<HashSet<CompanyDepartmentDto>>> GetAllCompanyDepartment()
        {
            var result = new Result<HashSet<CompanyDepartmentDto>>();
            var entities = await _unitWork.GetRepository<CompanyDepartment>().GetAllAsync("Company", "Department");
            var mappedEntity = _mapper.Map<HashSet<CompanyDepartmentDto>>(entities);
            result.Data = mappedEntity;
            return result;
        }
        [Validator(typeof(GetCompanyDepartmanByIdValidator))]
        public async Task<Result<CompanyDepartmentDto>> GetCompanyDepartmentById(GetCompanyDepartmentByIdRM getCompanyDepartmentById)
        {
            var result = new Result<CompanyDepartmentDto>();
            var entityControl = await _unitWork.GetRepository<CompanyDepartment>().AnyAsync(x => x.Id == getCompanyDepartmentById.Id);
            if (!entityControl)
            {
                throw new NotFoundException("İstenen Şirket/Departman kaydı bulunamadı.");
            }

            var existEntity = await _unitWork.GetRepository<CompanyDepartment>().GetSingleByFilterAsync(x => x.Id == getCompanyDepartmentById.Id, "Company", "Department");
            var mappedEntity = _mapper.Map<CompanyDepartmentDto>(existEntity);
            result.Data = mappedEntity;
            return result;
        }

        [Validator(typeof(GetDepartmentByCompanyIdRMValidator))]
        public async Task<Result<HashSet<DepartmentDto>>> GetDepartmentByCompanyId(GetDepartmentByCompanyIdRM getDepartmentByCompanyIdRM)
        {
            var result = new Result<HashSet<DepartmentDto>>();
            var companyControl = await _unitWork.GetRepository<CompanyDepartment>().AnyAsync(x => x.CompanyId == getDepartmentByCompanyIdRM.CompanyId);
            if (!companyControl)
            {
                throw new NotFoundException("İstenen Şirkete ait Şirket/Departman kaydı bulunamadı.");
            }

            var companyDepartments = await _unitWork.GetRepository<CompanyDepartment>().GetByFilterAsync(x => x.CompanyId == getDepartmentByCompanyIdRM.CompanyId);
            var companyDepartmentDtos = _mapper.Map<HashSet<CompanyDepartmentDto>>(companyDepartments);
            
            HashSet<DepartmentDto> DepartmentDtos = new();

            foreach(var companyDepartmentDto in companyDepartmentDtos)
            {
                var department = await _unitWork.GetRepository<Department>().GetById(companyDepartmentDto.DepartmentId);
                var departmentDto = _mapper.Map<DepartmentDto>(department);
                DepartmentDtos.Add(departmentDto);
            }

            result.Data = DepartmentDtos;
            return result;
        }
    }
}
