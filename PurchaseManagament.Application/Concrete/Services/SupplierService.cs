using AutoMapper;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Attributes;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Suppliers;
using PurchaseManagament.Application.Concrete.Validators.Supplier;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Application.Exceptions;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Persistence.Abstract.UnitWork;

namespace PurchaseManagament.Application.Concrete.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;

        public SupplierService(IMapper mapper, IUnitWork unitWork)
        {
            _mapper = mapper;
            _unitWork = unitWork;
        }

        //[Validator(typeof(CreateSupplierValidator))]
        public async Task<Result<bool>> CreateSupplier(CreateSupplierRM createSupplierRM)
        {
            var result = new Result<bool>();
            var existEntity = await _unitWork.GetRepository<Supplier>().AnyAsync(z => z.Name == createSupplierRM.Name);
            if (existEntity)
            {
                throw new AlreadyExistsException("Böyle bir şirket ismi zaten mevcut.");
            }            
            
            var mappedEntity = _mapper.Map<Supplier>(createSupplierRM);
            _unitWork.GetRepository<Supplier>().Add(mappedEntity);
            var resultBool = await _unitWork.CommitAsync();
            result.Data = resultBool;
            return result;
        }

        public async Task<Result<HashSet<SupplierDto>>> GetAllSupplier()
        {
            var result = new Result<HashSet<SupplierDto>>();
            var entities = await _unitWork.GetRepository<Supplier>().GetAllAsync();
            var mappedEntity = _mapper.Map<HashSet<SupplierDto>>(entities);
            result.Data = mappedEntity;
            return result;
        }

        public async Task<Result<SupplierDto>> GetSupplierById(GetSupplierByIdRM getSupplierByIdRM)
        {
            var result = new Result<SupplierDto>();
            var entityControl = await _unitWork.GetRepository<Supplier>().AnyAsync(x => x.Id == getSupplierByIdRM.Id);
            if (!entityControl)
            {
                throw new Exception($"Şirket ID {getSupplierByIdRM.Id} bulunamadı.");
            }

            var existEntity = await _unitWork.GetRepository<Supplier>().GetById(getSupplierByIdRM.Id);
            var mappedEntity = _mapper.Map<SupplierDto>(existEntity);
            result.Data = mappedEntity;
            return result;
        }

        //[Validator(typeof(UpdateSupplierValidator))]
        public async Task<Result<bool>> UpdateSupplier(UpdateSupplierRM updateSupplierRM)
        {
            var result = new Result<bool>();
            var existEntity = await _unitWork.GetRepository<Supplier>().AnyAsync(x => x.Id == updateSupplierRM.Id);
            if (!existEntity)
            {
                throw new Exception("Bu id ye sahip bir şirket bulunamadı.");
            }
            var entity = await _unitWork.GetRepository<Supplier>().GetById(updateSupplierRM.Id);
            var mappedEntity = _mapper.Map(updateSupplierRM, entity);
            _unitWork.GetRepository<Supplier>().Update(mappedEntity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        public async Task<Result<bool>> DeleteSupplier(GetByIdVM id)
        {
            var result = new Result<bool>();
            var existEntity = await _unitWork.GetRepository<Supplier>().AnyAsync(x => x.Id == id.Id);
            if (!existEntity)
            {
                throw new Exception("Böyle bir tedarikci silinmek için bulunamadı.");
            }
            var entity = await _unitWork.GetRepository<Supplier>().GetById(id.Id);
            entity.IsDeleted = true;
            _unitWork.GetRepository<Supplier>().Update(entity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        public async Task<Result<bool>> DeleteSupplierPermanent(GetByIdVM id)
        {
            var result = new Result<bool>();
            var existEntity = await _unitWork.GetRepository<Supplier>().AnyAsync(x => x.Id == id.Id);
            if (!existEntity)
            {
                throw new Exception("Böyle bir Tedarikci silinmek için bulunamadı.");
            }
            var entity = await _unitWork.GetRepository<Supplier>().GetById(id.Id);
            _unitWork.GetRepository<Supplier>().Delete(entity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }
    }
}
