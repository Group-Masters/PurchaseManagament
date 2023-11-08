using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface IImgProductService
    {
        Task<Result<bool>> CreateImgProduct(ImgProduct ımgProduct);
    }
}
