﻿using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.ImgProduct;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface IImgProductService
    {
        Task<Result<long>> CreateImgProduct(CreateImgProductRM ımgProduct);


        Task<Result<HashSet<ImgProductDto>>> GetAllImgProduct();

    }
}
