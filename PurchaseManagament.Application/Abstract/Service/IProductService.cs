using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyStocks;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Products;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface IProductService
    {
        Task<Result<long>> CreateProduct(CreateProductRM createProductRM);
        Task<Result<long>> UpdateProduct(UpdateProductRM updateProductRM);
        Task<Result<bool>> DeleteProductPermanent(Int64 id);
        Task<Result<bool>> DeleteProduct(Int64 id);

        //GET METHODS
        Task<Result<HashSet<ProductDto>>> GetAllProduct();
    }
}
