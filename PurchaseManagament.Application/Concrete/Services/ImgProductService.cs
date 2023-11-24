using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Attributes;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.ImgProduct;
using PurchaseManagament.Application.Concrete.Validators.Image;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Application.Exceptions;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Persistence.Abstract.UnitWork;
using PurchaseManagament.Utils;

namespace PurchaseManagament.Application.Concrete.Services
{
    [NullCheckParam]
    public class ImgProductService : IImgProductService
    {

        private readonly IUnitWork _unitWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;

        public ImgProductService(IUnitWork unitWork, IMapper mapper, IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            _unitWork = unitWork;
            _mapper = mapper;
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }
        [Validator(typeof(CreateProductImageValidator))]
        public async Task<Result<long>> CreateImgProduct(CreateImgProductRM ımgProduct)
        {


            var result = new Result<long>();

            var productExists = await _unitWork.GetRepository<Product>().GetSingleByFilterAsync(x => x.Id == ımgProduct.ProductId, "ImgProduct");
            if (productExists is null)
            {
                throw new NotFoundException($"Ürün Bulunamadı.");
            }
            //Dosyanın ismi belirleniyor.
            var fileName = PathUtil.GenerateFileNameFromBase64File(ımgProduct.ImageSrc);
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration["Paths:ProductImages"], fileName);

            //Base64 string olarak gelen dosya byte dizisine çevriliyor.
            var imageDataAsByteArray = Convert.FromBase64String(ımgProduct.ImageSrc);
            //byte dizisi FileStream'e yazmak üzere FileStream'e aktarılıyor.
            var ms = new MemoryStream(imageDataAsByteArray);
            ms.Position = 0;

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                ms.CopyTo(fs);
                fs.Close();
            }
            //Dosyanı yolu [Projenin kök dizininin yolu]+["images"]+"["product-images"]+["dosyanın adı.uzantısı"]

            var productImageEntity = _mapper.Map(ımgProduct,productExists.ImgProduct);
            //images/product-images/14_8_2023_21_56_39_987.png
            productImageEntity.ImageSrc = $"{_configuration["Paths:ProductImages"]}/{fileName}";

            //Dosyaya ait bilgileri dbye yaz.
            if (productExists.ImgProduct is null)
            {
                _unitWork.GetRepository<ImgProduct>().Add(productImageEntity);
            }
            else
            {
                _unitWork.GetRepository<ImgProduct>().Update(productImageEntity);
            }

            await _unitWork.CommitAsync();

            result.Data = productImageEntity.Id;
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
