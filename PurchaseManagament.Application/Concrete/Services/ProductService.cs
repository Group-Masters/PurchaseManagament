using AutoMapper;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyStocks;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Products;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Persistence.Abstract.UnitWork;

namespace PurchaseManagament.Application.Concrete.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;

        public ProductService(IMapper mapper, IUnitWork unitWork)
        {
            _mapper = mapper;
            _unitWork = unitWork;
        }

        public async Task<Result<long>> CreateProduct(CreateProductRM createProductRM)
        {
            var result = new Result<long>();
            var mappedEntity = _mapper.Map<Product>(createProductRM);
            _unitWork.GetRepository<Product>().Add(mappedEntity);
            await _unitWork.CommitAsync();
            result.Data = mappedEntity.Id;
            return result;
        }

        public async Task<Result<bool>> DeleteProduct(long id)
        {
            var result = new Result<bool>();
            var entity = _unitWork.GetRepository<Product>().GetById(id);
            if (entity is null)
            {
                throw new Exception("Böyle id ye sahip stok ürünü bulunamamıştır.");
            }
            _unitWork.GetRepository<CompanyStock>().Delete(entity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        public async Task<Result<bool>> DeleteProductPermanent(long id)
        {
            var result = new Result<bool>();
            var entity = _unitWork.GetRepository<Product>().GetById(id);
            if (entity is null)
            {
                throw new Exception("Böyle id ye sahip stok ürünü bulunamamıştır.");
            }
            _unitWork.GetRepository<CompanyStock>().Delete(entity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        public async Task<Result<HashSet<ProductDto>>> GetAllProduct()
        {
            var result = new Result<HashSet<ProductDto>>();
            var entities = _unitWork.GetRepository<Product>().GetAllAsync();
            var mappedEntities = _mapper.Map<HashSet<ProductDto>>(await entities);
            result.Data = mappedEntities;
            return result;
        }

        public async Task<Result<long>> UpdateProduct(UpdateProductRM updateProductRM)
        {
            var result = new Result<long>();
            var entity = await _unitWork.GetRepository<Product>().GetById(updateProductRM.Id);
            if (entity is null)
            {
                throw new Exception("Stok güncellemesi için id eşleşmesi başarısız oldu.");
            }
            _unitWork.GetRepository<Product>().Update(entity);
            await _unitWork.CommitAsync();
            result.Data = entity.Id;
            return result;
        }
    }
}
