﻿using AutoMapper;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Attributes;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.ImgProduct;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Persistence.Abstract.UnitWork;

namespace PurchaseManagament.Application.Concrete.Services
{
    [NullCheckParam]
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
            var existsEntity = await _unitWork.GetRepository<ImgProduct>().AnyAsync(z => z.ProductId == ımgProduct.ProductId);
            if(existsEntity is false)
            {
                var mappedEntity = _mapper.Map<ImgProduct>(ımgProduct);
                _unitWork.GetRepository<ImgProduct>().Add(mappedEntity);
                await _unitWork.CommitAsync();
            }
            else
            {
                var mappedEntity = await  _unitWork.GetRepository<ImgProduct>().GetSingleByFilterAsync(q => q.ProductId == ımgProduct.ProductId);
                var entity = _mapper.Map(ımgProduct, mappedEntity);
                _unitWork.GetRepository<ImgProduct>().Update(entity);
                await _unitWork.CommitAsync();
            }
            return result;
        }

        public async Task<Result<HashSet<ImgProductDto>>> GetAllImgProduct()
        {
            var result = new Result<HashSet<ImgProductDto>>();
            var entities = await _unitWork.GetRepository<ImgProduct>().GetAllAsync();
            var mappedEnties = _mapper.Map<HashSet<ImgProductDto>>(entities);
            result.Data = mappedEnties; 
            result.Success = true; 
            return result;
        }
    }
}
