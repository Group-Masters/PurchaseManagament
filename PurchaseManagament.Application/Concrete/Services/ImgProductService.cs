using AutoMapper;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.RequestModels.ImgProduct;
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
        private readonly IMapper _mapper;
        public ImgProductService(IUnitWork unitWork, IMapper mapper)
        {
            _unitWork = unitWork;
            _mapper = mapper;
        }

        public async Task<Result<long>> CreateImgProduct(CreateImgProductRM ımgProduct)
        {
            var result = new Result<long>();
            var mappedEntity = _mapper.Map<ImgProduct>(ımgProduct);
            _unitWork.GetRepository<ImgProduct>().Add(mappedEntity);
            await _unitWork.CommitAsync();
            result.Data = mappedEntity.Id;


            return result;
        }
    }
}
