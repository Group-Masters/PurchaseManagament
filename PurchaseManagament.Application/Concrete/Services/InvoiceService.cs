using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Configuration;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Attributes;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Invoices;
using PurchaseManagament.Application.Concrete.Validators.Invoices;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Application.Exceptions;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Domain.Enums;
using PurchaseManagament.Persistence.Abstract.UnitWork;
using PurchaseManagament.Utils;
using System.Xml;


namespace PurchaseManagament.Application.Concrete.Services
{
    [NullCheckParam]
    public class InvoiceService : IInvoiceService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;
        private readonly IRequestService _requestService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;

        public InvoiceService(IMapper mapper, IUnitWork unitWork, IRequestService requestService, IWebHostEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _mapper = mapper;
            _unitWork = unitWork;
            _requestService = requestService;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }

        #region CRUD Operations

        //[Validator(typeof(CreateInvoiceValidator))]
        public async Task<Result<long>> CreateInvoice(CreateInvoiceRM create)
        {
            XmlDocument xmlVerisi = new XmlDocument();
            xmlVerisi.Load("https://www.tcmb.gov.tr/kurlar/today.xml");

            var result = new Result<long>();

            var mappedEntity = _mapper.Map<Invoice>(create);
            var offerEntity = await _unitWork.GetRepository<Offer>().GetSingleByFilterAsync(x => x.Id == create.OfferId, "Currency");
            var materialOffer = await _unitWork.GetRepository<MaterialOffer>().GetByFilterAsync(x => x.OfferId == create.OfferId,"Material");

            decimal totalPrice = 0;
            foreach (var item in materialOffer)
            {
                totalPrice += item.OfferedPrice;
            }
            //if (create.ImageSrc != null)
            //{
            //    //Dosyanın ismi belirleniyor.
            //    var fileName = PathUtil.GenerateFileNameFromBase64File(create.ImageSrc);
            //    var filePath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration["Paths:InvoiceImages"], fileName);

            //    //Base64 string olarak gelen dosya byte dizisine çevriliyor.
            //    var imageDataAsByteArray = Convert.FromBase64String(create.ImageSrc);
            //    //byte dizisi FileStream'e yazmak üzere FileStream'e aktarılıyor.
            //    var ms = new MemoryStream(imageDataAsByteArray);
            //    ms.Position = 0;

            //    using (FileStream fs = new FileStream(filePath, FileMode.Create))
            //    {
            //        ms.CopyTo(fs);
            //        fs.Close();
            //    }
            //    //Dosyanı yolu [Projenin kök dizininin yolu]+["images"]+"["product-images"]+["dosyanın adı.uzantısı"]


            //    //images/product-images/14_8_2023_21_56_39_987.png
            //    mappedEntity.ImageSrc = $"{_configuration["Paths:InvoiceImages"]}/{fileName}";
            //}

            if(xmlVerisi != null)
            {
                mappedEntity.TRY_Rate = offerEntity.Currency.Name == "TRY" ? 1 * totalPrice : totalPrice * Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", $"{offerEntity.Currency.Name}")).InnerText.Replace('.', ','));
            }
            else
            {
                mappedEntity.TRY_Rate = totalPrice;
            }

            offerEntity.Status = Status.FaturaEklendi;
            foreach (var item in materialOffer)
            {
                item.Material.State = Status.FaturaEklendi;
                _unitWork.GetRepository<Material>().Update(item.Material);
            }
            _unitWork.GetRepository<Offer>().Update(offerEntity);
            _unitWork.GetRepository<Invoice>().Add(mappedEntity);

            await _unitWork.CommitAsync();
            result.Data = mappedEntity.Id;
            return result;
        }

        [Validator(typeof(UpdateInvoiceValidator))]
        public async Task<Result<long>> UpdateInvoice(UpdateInvoiceRM updateInvoiceRM)
        {
            var result = new Result<long>();
            var entity = await _unitWork.GetRepository<Invoice>().GetById(updateInvoiceRM.Id);
            if (entity is null)
            {
                throw new NotFoundException("Güncellenmek istenen Fatura kaydı bulunamadı.");
            }
            _mapper.Map(updateInvoiceRM, entity);
            _unitWork.GetRepository<Invoice>().Update(entity);

            await _unitWork.CommitAsync();
            result.Data = entity.Id;
            return result;
        }

        public async Task<Result<long>> UpdateInvoiceState(UpdateInvoiceStatusRM update)
        {
            var result = new Result<long>();

            var invoice = await _unitWork.GetRepository<Invoice>().GetSingleByFilterAsync(x => x.Id == update.Id);

            var updatedInvoice = _mapper.Map(update, invoice);
            if (updatedInvoice.Status == Status.Tamamlandı)
            {
                updatedInvoice.Offer.Status = Status.Tamamlandı;
                var offerMaterials = await _unitWork.GetRepository<MaterialOffer>().GetByFilterAsync(x => x.OfferId == updatedInvoice.OfferId);
                HashSet<long> materialRequestIds = new();
                foreach (var offerMaterial in offerMaterials)
                {
                    offerMaterial.Material.State = Status.Tamamlandı;
                    if (!materialRequestIds.Contains(offerMaterial.Material.RequestId))
                    {
                        materialRequestIds.Add(offerMaterial.Material.RequestId);
                    }
                }
                _unitWork.GetRepository<Invoice>().Update(updatedInvoice);

                foreach (var requestId in materialRequestIds)
                {
                    var requestState = await _requestService.RequestStatusUpdate(new GetByIdVM { Id = requestId });
                    if (requestState.Data.State == Status.Tamamlandı)
                    {
                        int count = 1;
                        string printCompletedMaterials = "";
                        var materials = await _unitWork.GetRepository<Material>().GetByFilterAsync(x => x.RequestId == requestId);
                        foreach (var material in materials)
                        {
                            printCompletedMaterials += $"\n{count}-) {material.Product.Name}: {material.Quantity} {material.Product.MeasuringUnit}";
                            count++;
                        }
                        SenderUtils.SendMail(requestState.Data.RequestEmployee.EmployeeDetail.Email, "TAMAMLANAN TALEP",
                            $"{requestState.Data.Id} talep numaralı talebiniz tamamlanmıştır. Stoktan temin edebilirsiniz . Talep içeriğiniz : " +
                            $"{printCompletedMaterials}");
                    }
                }
            }

            await _unitWork.CommitAsync();
            result.Data = updatedInvoice.Id;
            return result;
        }

        [Validator(typeof(UpdateInvoiceImageVM))]
        public async Task<Result<long>> UpdateInvoiceImage(UpdateInvoiceImageVM updateInvoiceImageVM)
        {
            var result = new Result<long>();
            var entity = await _unitWork.GetRepository<Invoice>().GetSingleByFilterAsync(x => x.Id == updateInvoiceImageVM.Id);
            if (entity is null)
            {
                throw new NotFoundException("Fatura Bulunamadı.");

            }
            //Dosyanın ismi belirleniyor.
            var fileName = PathUtil.GenerateFileNameFromBase64File(updateInvoiceImageVM.ImageString);
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration["Paths:InvoiceImages"], fileName);

            //Base64 string olarak gelen dosya byte dizisine çevriliyor.
            var imageDataAsByteArray = Convert.FromBase64String(updateInvoiceImageVM.ImageString);
            //byte dizisi FileStream'e yazmak üzere FileStream'e aktarılıyor.
            var ms = new MemoryStream(imageDataAsByteArray);
            ms.Position = 0;

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                ms.CopyTo(fs);
                fs.Close();
            }
            //Dosyanı yolu [Projenin kök dizininin yolu]+["images"]+"["product-images"]+["dosyanın adı.uzantısı"]


            //images/product-images/14_8_2023_21_56_39_987.png
            updateInvoiceImageVM.ImageString = $"{_configuration["Paths:InvoiceImages"]}/{fileName}";
            var updatedEntity = _mapper.Map(updateInvoiceImageVM, entity);
            _unitWork.GetRepository<Invoice>().Update(updatedEntity);

            await _unitWork.CommitAsync();
            result.Data = entity.Id;
            return result;
        }

        [Validator(typeof(GetByIdValidator))]
        public async Task<Result<bool>> DeleteInvoice(GetByIdVM id)
        {
            var result = new Result<bool>();

            var entity = await _unitWork.GetRepository<Invoice>().GetById(id.Id);
            if (entity is null)
            {
                throw new NotFoundException($"Silinmek istenen Fatura kaydı bulunamadı.");
            }
            entity.IsDeleted = true;
            _unitWork.GetRepository<Invoice>().Update(entity);

            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        [Validator(typeof(GetByIdValidator))]
        public async Task<Result<bool>> DeleteInvoicePermanent(GetByIdVM id)
        {
            var result = new Result<bool>();

            var entity = _unitWork.GetRepository<Invoice>().GetById(id.Id);
            if (entity is null)
            {
                throw new NotFoundException($"Silinmek istenen Fatura kaydı bulunamadı.");
            }
            _unitWork.GetRepository<Invoice>().Delete(await entity);

            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        #endregion


        #region GET Operations

        public async Task<Result<HashSet<InvoiceDto>>> GetAllInvoice()
        {
            var result = new Result<HashSet<InvoiceDto>>();

            var entities = await _unitWork.GetRepository<Invoice>().GetAllAsync
                ("Offer.ApprovingEmployee.CompanyDepartment.Company", "Offer.Supplier", "Offer.Currency");
            var mappedEntity = _mapper.Map<HashSet<InvoiceDto>>(entities);

            result.Data = mappedEntity;
            return result;
        }

        [Validator(typeof(GetInvoiceByIdValidator))]
        public async Task<Result<InvoiceDto>> GetInvoiceById(GetInvoiceByIdRM getInvoiceById)
        {
            var result = new Result<InvoiceDto>();

            var existEntity = await _unitWork.GetRepository<Invoice>().GetSingleByFilterAsync(x => x.Id == getInvoiceById.Id, 
                "Offer.ApprovingEmployee.CompanyDepartment.Company", "Offer.Supplier", "Offer.Currency");
            var mappedEntity = _mapper.Map<InvoiceDto>(existEntity);

            var materials = await _unitWork.GetRepository<MaterialOffer>().GetByFilterAsync(x => x.OfferId == existEntity.OfferId, 
                "Offer.Supplier", "Offer.Currency", "Material.Product.MeasuringUnit");
            var materialOfferDtos = _mapper.Map<HashSet<MaterialOfferDto>>(materials);

            mappedEntity.MaterialOfferDtos = materialOfferDtos;

            result.Data = mappedEntity;
            return result;
        }

        [Validator(typeof(GetInvoiceByIdValidator))]
        public async Task<Result<HashSet<InvoiceDto>>> GetInvoicesByCompanyId(GetInvoiceByIdRM getInvoiceById)
        {
            var result = new Result<HashSet<InvoiceDto>>();

            var entities = await _unitWork.GetRepository<Invoice>().GetByFilterAsync(x => x.Offer.ApprovingEmployee.CompanyDepartment.CompanyId == getInvoiceById.Id, 
                "Offer.ApprovingEmployee.CompanyDepartment.Company", "Offer.Supplier", "Offer.Currency");
            var mappedEntity = _mapper.Map<HashSet<InvoiceDto>>(entities);

            foreach(var entity in mappedEntity)
            {
                var materials = await _unitWork.GetRepository<MaterialOffer>().GetByFilterAsync(x => x.OfferId == entity.OfferId,
                    "Offer.Supplier", "Offer.Currency", "Material.Product.MeasuringUnit");
                var materialOfferDtos = _mapper.Map<HashSet<MaterialOfferDto>>(materials);
                entity.MaterialOfferDtos = materialOfferDtos;
            }

            result.Data = mappedEntity;
            return result;
        }

        [Validator(typeof(GetInvoiceByIdValidator))]
        public async Task<Result<HashSet<InvoiceDto>>> GetPendingInvoicesByCompanyId(GetInvoiceByIdRM getInvoiceById)
        {
            var result = new Result<HashSet<InvoiceDto>>();

            var entities = await _unitWork.GetRepository<Invoice>().GetByFilterAsync
                (x => x.Offer.ApprovingEmployee.CompanyDepartment.CompanyId == getInvoiceById.Id && x.Status == Status.Beklemede,
                "Offer.ApprovingEmployee.CompanyDepartment.Company", "Offer.Supplier", "Offer.Currency");
            var mappedEntity = _mapper.Map<HashSet<InvoiceDto>>(entities);

            foreach (var entity in mappedEntity)
            {
                var materials = await _unitWork.GetRepository<MaterialOffer>().GetByFilterAsync(x => x.OfferId == entity.OfferId,
                    "Offer.Supplier", "Offer.Currency", "Material.Product.MeasuringUnit");
                var materialOfferDtos = _mapper.Map<HashSet<MaterialOfferDto>>(materials);
                entity.MaterialOfferDtos = materialOfferDtos;
            }

            result.Data = mappedEntity;
            return result;
        }
        #endregion
    }
}

