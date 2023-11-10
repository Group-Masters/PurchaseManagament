using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Products;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface IProductService
    {
        Task<Result<long>> CreateProduct(CreateProductRM createProductRM);
        Task<Result<long>> UpdateProduct(UpdateProductRM updateProductRM);
        Task<Result<bool>> DeleteProductPermanent(GetByIdVM id);
        Task<Result<bool>> DeleteProduct(GetByIdVM id);

        //GET METHODS
        Task<Result<HashSet<ProductDto>>> GetAllProduct();
    }
}
