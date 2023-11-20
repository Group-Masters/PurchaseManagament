using AutoMapper;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Attributes;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Products;
using PurchaseManagament.Application.Concrete.Validators.Product;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Application.Exceptions;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Persistence.Abstract.UnitWork;

namespace PurchaseManagament.Application.Concrete.Services
{
    [NullCheckParam]
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;

        public ProductService(IMapper mapper, IUnitWork unitWork)
        {
            _mapper = mapper;
            _unitWork = unitWork;
        }

        [Validator(typeof(CreateProductValidator))]
        public async Task<Result<long>> CreateProduct(CreateProductRM createProductRM)
        {
            var result = new Result<long>();
            var mappedEntity = _mapper.Map<Product>(createProductRM);
            _unitWork.GetRepository<Product>().Add(mappedEntity);
            await _unitWork.CommitAsync();
            result.Data = mappedEntity.Id;
            return result;
        }


        [Validator(typeof(DeleteProductValidator))]
        public async Task<Result<bool>> DeleteProduct(GetByIdVM id)
        {
            var result = new Result<bool>();
            var entity = await _unitWork.GetRepository<Product>().GetById(id.Id);
            if (entity is null)
            {
                throw new NotFoundException("Silinmek istenen Ürün kaydı bulunamadı.");
            }
            entity.IsDeleted = true;
            _unitWork.GetRepository<Product>().Update(entity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        [Validator(typeof(DeleteProductValidator))]
        public async Task<Result<bool>> DeleteProductPermanent(GetByIdVM id)
        {
            var result = new Result<bool>();
            var entity = _unitWork.GetRepository<Product>().GetById(id.Id);
            if (entity is null)
            {
                throw new NotFoundException("Silinmek istenen Ürün kaydı bulunamadı.");
            }
            _unitWork.GetRepository<Product>().Delete(await entity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        public async Task<Result<HashSet<ProductDto>>> GetAllProduct()
        {
            var result = new Result<HashSet<ProductDto>>();
            var entities = _unitWork.GetRepository<Product>().GetAllAsync("MeasuringUnit", "ImgProduct");
            var mappedEntities = _mapper.Map<HashSet<ProductDto>>(await entities);
            result.Data = mappedEntities;
            return result;
        }

        [Validator(typeof(UpdateProductValidator))]
        public async Task<Result<long>> UpdateProduct(UpdateProductRM updateProductRM)
        {
            var result = new Result<long>();
            var entity = await _unitWork.GetRepository<Product>().GetById(updateProductRM.Id);
            if (entity is null)
            {
                throw new NotFoundException("Güncellenmek istenen Ürün kaydı bulunamadı.");
            }
            var mappedEntity = _mapper.Map(updateProductRM, entity);
            _unitWork.GetRepository<Product>().Update(mappedEntity);
            await _unitWork.CommitAsync();
            result.Data = entity.Id;
            return result;
        }
    }
}
