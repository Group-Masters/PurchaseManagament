using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Persistence.Abstract.UnitWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Concrete.Services
{
    public class ImgProductService : IImgProductService
    {

        private readonly IUnitWork _unitWork;
        public ImgProductService(IUnitWork unitWork)
        {
            _unitWork = unitWork;
        }

        public async Task<Result<bool>> CreateImgProduct(ImgProduct ımgProduct)
        {
            var result = new Result<bool>();

            _unitWork.GetRepository<ImgProduct>().Add(ımgProduct);
            await _unitWork.CommitAsync();
            result.Data = true;


            return result;
        }
    }
}
