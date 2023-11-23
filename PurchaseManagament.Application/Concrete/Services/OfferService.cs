using AutoMapper;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Attributes;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Offers;
using PurchaseManagament.Application.Concrete.Validators.Offer;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Application.Exceptions;
using PurchaseManagament.Domain.Abstract;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Domain.Enums;
using PurchaseManagament.Persistence.Abstract.UnitWork;
using PurchaseManagament.Utils;
using System.Xml;

namespace PurchaseManagament.Application.Concrete.Services
{
    [NullCheckParam]
    public class OfferService : IOfferService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;
        private readonly ILoggedService _loggedService;
        private readonly IMaterialOfferService _materialOfferService;

        public OfferService(IMapper mapper, IUnitWork unitWork, ILoggedService loggedService, IMaterialOfferService materialOfferService)
        {
            _mapper = mapper;
            _unitWork = unitWork;
            _loggedService = loggedService;
            _materialOfferService = materialOfferService;
        }

        #region Offer CRUD Operations
        [Validator(typeof(CreateOfferValidator))]
        public async Task<Result<long>> CreateOffer(CreateOfferRM create)
        {
            var result = new Result<long>();
            var mappedEntity = _mapper.Map<Offer>(create);
            _unitWork.GetRepository<Offer>().Add(mappedEntity);
            await _unitWork.CommitAsync();
            result.Data = mappedEntity.Id;
            return result;
        }

        [Validator(typeof(UpdateOfferValidator))]
        public async Task<Result<long>> UpdateOffer(UpdateOfferRM update)
        {
            var result = new Result<long>();
            var entity = await _unitWork.GetRepository<Offer>().GetById(update.Id);
            if (entity is null)
            {
                throw new NotFoundException("Güncellenmek istenen Teklif kaydı bulunamadı.");
            }

            var mappedEntity = _mapper.Map(update, entity);
            _unitWork.GetRepository<Offer>().Update(mappedEntity);

            await _unitWork.CommitAsync();
            result.Data = entity.Id;
            return result;
        }

        [Validator(typeof(UpdateOfferStateValidator))]
        public async Task<Result<long>> UpdateOfferState(UpdateOfferStateRM update)
        {
            var result = new Result<long>();
            var offer = await _unitWork.GetRepository<Offer>().GetSingleByFilterAsync(x => x.Id == update.Id);

            var offerMaterials = await _unitWork.GetRepository<MaterialOffer>().GetByFilterAsync(x => x.OfferId == update.Id, "Offer.Supplier", "Material.Product.MeasuringUnit", "Offer.Currency");
            var offerMaterialDtos = _mapper.Map<HashSet<MaterialOfferDto>>(offerMaterials);

            if (offer.SupplierId == 1 && update.Status == Status.YönetimOnay)
            {
                foreach (var offerMaterial in offerMaterialDtos)
                {
                    var materialEntity = await _unitWork.GetRepository<Material>().GetById(offerMaterial.MaterialId);
                    materialEntity.State = Status.FaturaEklendi;

                    _unitWork.GetRepository<Material>().Update(materialEntity);
                    update.Status = Status.FaturaEklendi;
                }
            }else if(update.Status == Status.YönetimBekleme)
            {
                foreach (var offerMaterial in offerMaterialDtos)
                {
                    var materialEntity = await _unitWork.GetRepository<Material>().GetById(offerMaterial.MaterialId);
                    materialEntity.State = update.Status;
                    _unitWork.GetRepository<Material>().Update(materialEntity);

                    materialEntity.State = Status.YönetimBekleme;

                    var declinedOffers = await _unitWork.GetRepository<MaterialOffer>().GetByFilterAsync(x => x.OfferId != offerMaterial.OfferId && x.MaterialId == offerMaterial.MaterialId);
                    foreach(var item in declinedOffers)
                    {
                        item.Offer.Status = Status.Reddedildi;
                        _unitWork.GetRepository<Offer>().Update(item.Offer);
                    }
                }
            }else if(update.Status == Status.YönetimOnay || update.Status == Status.YönetimRed || update.Status == Status.FaturaEklendi || update.Status == Status.Tamamlandı)
            {
                HashSet<Material> declinedMaterials = new();
                Request request = new Request();
                foreach(var offerMaterial in offerMaterialDtos)
                {
                    var materialEntity = await _unitWork.GetRepository<Material>().GetSingleByFilterAsync(x => x.Id == offerMaterial.MaterialId, "Product.MeasuringUnit");
                    materialEntity.State = update.Status;
                    _unitWork.GetRepository<Material>().Update(materialEntity);
                    if(update.Status == Status.YönetimRed)
                    {
                        declinedMaterials.Add(materialEntity);
                        request = materialEntity.Request;
                    }
                }
                if(declinedMaterials.Count > 0)
                {
                    string printDeclinedMaterial = new("");
                    int i = 1;
                    foreach(var item in declinedMaterials)
                    {
                        printDeclinedMaterial += $"\n{i}-) {item.Product.Name} {item.Quantity} {item.Product.MeasuringUnit}";
                        i++;
                    }
                    SenderUtils.SendMail(request.RequestEmployee.EmployeeDetail.Email, "Talep Bilgilendirme", $"Oluşturmuş olduğunuz {request.Id} numaralı talebinizdeki bazı ürünler Yönetim tarafınca reddetilmiştir. Reddedilen ürünler listesi:{printDeclinedMaterial}");
                }
            }

            _mapper.Map(update, offer);
            offer.ApprovingEmployeeId = (Int64)_loggedService.UserId;
            _unitWork.GetRepository<Offer>().Update(offer);

            await _unitWork.CommitAsync();
            result.Data = offer.Id;
            return result;
        }


        /// <summary>
        /// Teklifin bütçe sınırı kontrolör değerini günceller.
        /// </summary>
        /// <param name="offerId">Offer.Id</param>
        /// <returns>Offer.AboveThreshold</returns>
        public async Task<Result<bool>> UpdateAboveThreshold(GetOfferByIdRM offerId)
        {
            XmlDocument xmlVerisi = new XmlDocument();
            xmlVerisi.Load("https://www.tcmb.gov.tr/kurlar/today.xml");

            var result = new Result<bool>();
            decimal totalPrice = 0;

            var offer = await _unitWork.GetRepository<Offer>().GetById(offerId);
            offer.AboveThreshold = false;

            var offerMaterials = _unitWork.GetRepository<MaterialOffer>().GetByFilterAsync(x => x.OfferId == offerId.Id, "Product.MeasuringUnit");
            var threshold = _unitWork.GetRepository<MaterialOffer>().GetSingleByFilterAsync(x => x.OfferId == offerId.Id).Result.Material.Request.RequestEmployee.CompanyDepartment.Company.ManagerThreshold;
            var materialOfferDtos = _mapper.Map<HashSet<MaterialOfferDto>>(offerMaterials);
            foreach (var materialOfferDto in materialOfferDtos)
            {
                totalPrice += materialOfferDto.OfferedPrice;
            }
            if (offer.Currency.Name != "TRY")
            {
                var rate = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", $"{offer.Currency.Name}")).InnerText.Replace('.', ','));
                totalPrice = rate * totalPrice;
            }
            if (totalPrice >= threshold)
            {

                offer.AboveThreshold = true;
                _unitWork.GetRepository<Offer>().Update(offer);
                await _unitWork.CommitAsync();
            }
            result.Data = offer.AboveThreshold;
            return result;
        }

        [Validator(typeof(GetByIdValidator))]
        public async Task<Result<bool>> DeleteOffer(GetByIdVM id)
        {
            var result = new Result<bool>();
            var entity = await _unitWork.GetRepository<Offer>().GetById(id.Id);
            if (entity is null)
            {
                throw new NotFoundException("Silinmek istenen Teklif kaydı bulunamadı.");
            }
            entity.IsDeleted = true;
            _unitWork.GetRepository<Offer>().Update(entity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        [Validator(typeof(GetByIdValidator))]
        public async Task<Result<bool>> DeleteOfferPermanent(GetByIdVM id)
        {
            var result = new Result<bool>();
            var entity = _unitWork.GetRepository<Offer>().GetById(id.Id);
            if (entity is null)
            {
                throw new NotFoundException("Silinmek istenen Teklif kaydı bulunamadı.");
            }
            _unitWork.GetRepository<Offer>().Delete(await entity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        #endregion

        #region Offer Get Operations


        /// <summary>
        /// Teklifleri şirkete göre getirir.
        /// </summary>
        /// <param name="companyId">Company.Id</param>
        /// <returns>İstenen şirkete ait teklifleri OfferDto listesi olarak döner.</returns>
        public async Task<Result<HashSet<OfferDto>>> GetOfferByCompany(GetOfferByIdRM companyId)
        {
            var result = new Result<HashSet<OfferDto>>();

            var materialOffers = await _unitWork.GetRepository<MaterialOffer>().GetByFilterAsync(x => x.Material.Request.RequestEmployee.CompanyDepartment.CompanyId == companyId.Id);
            var company = _unitWork.GetRepository<Company>().GetById(companyId.Id);

            HashSet<long> offerList = new();
            foreach (var materialOffer in materialOffers)
            {
                if (!offerList.Contains(materialOffer.OfferId))
                {
                    offerList.Add(materialOffer.OfferId);
                }
            }

            HashSet<OfferDto> offerDtos = new();
            foreach (var offerId in offerList)
            {
                var offer = await _unitWork.GetRepository<Offer>().GetSingleByFilterAsync(x => x.Id == offerId, "Supplier", "Currency", "ApprovingEmployee");
                var offerDto = _mapper.Map<OfferDto>(offer);
                offerDto.CompanyName = company.Result.Name;
                offerDto.CompanyAddress = company.Result.Address;
            }

            result.Data = offerDtos;
            return result;
        }

        public async Task<Result<HashSet<OfferDto>>> GetAllOffer()
        {
            var result = new Result<HashSet<OfferDto>>();

            HashSet<long> companyIds = new();
            var companies = await _unitWork.GetRepository<Company>().GetAllAsync();
            foreach (var company in companies)
            {
                companyIds.Add(company.Id);
            }

            HashSet<OfferDto> offerDtos = new();
            foreach (var companyId in companyIds)
            {
                var offerDto = GetOfferByCompany(new GetOfferByIdRM { Id = companyId }).Result.Data;
                foreach(var offer in offerDto)
                {
                    offerDtos.Add(offer);
                }
            }

            result.Data = offerDtos;
            return result;
        }

        [Validator(typeof(GetOfferByIdValidator))]
        public async Task<Result<HashSet<OfferDto>>> GetAllOfferByRequestId(GetOfferByIdRM getOfferByRequestId)
        {
            var result = new Result<HashSet<OfferDto>>();

            var entities = await _unitWork.GetRepository<MaterialOffer>().GetByFilterAsync(x => x.Material.RequestId == getOfferByRequestId.Id);
            var request = _unitWork.GetRepository<Request>().GetById(getOfferByRequestId.Id);

            HashSet<long> offerList = new();
            foreach (var entity in entities)
            {
                if (!offerList.Contains(entity.OfferId))
                {
                    offerList.Add(entity.OfferId);
                }
            }

            HashSet<OfferDto> offerDtos = new();
            foreach (var offerId in offerList)
            {
                var offer = await _unitWork.GetRepository<Offer>().GetSingleByFilterAsync(x => x.Id == offerId, "Supplier", "Currency", "ApprovingEmployee");
                var offerDto = _mapper.Map<OfferDto>(offer);
                offerDto.CompanyName = request.Result.RequestEmployee.CompanyDepartment.Company.Name;
                offerDto.CompanyAddress = request.Result.RequestEmployee.CompanyDepartment.Company.Address;
            }

            result.Data = offerDtos;
            return result;
        }

        [Validator(typeof(GetOfferByIdValidator))]
        public Result<HashSet<OfferDto>> GetOfferByChairman(GetOfferByIdRM company)
        {
            var result = new Result<HashSet<OfferDto>>();

            var offerByCompany = GetOfferByCompany(company).Result.Data;
            HashSet<OfferDto> offerChairman = new();
            foreach (var offer in offerByCompany)
            {
                if (offer.Status == Status.YönetimBekleme && offer.AboveThreshold == true)
                {
                    offerChairman.Add(offer);
                }
            }
            var mappedEntity = _mapper.Map<HashSet<OfferDto>>(offerChairman);

            result.Data = mappedEntity;
            return result;
        }

        [Validator(typeof(GetOfferByIdValidator))]
        public Result<HashSet<OfferDto>> GetOfferByManager(GetOfferByIdRM company)
        {
            var result = new Result<HashSet<OfferDto>>();

            var offerByCompany = GetOfferByCompany(company).Result.Data;
            HashSet<OfferDto> offerManager = new();
            foreach (var offer in offerByCompany)
            {
                if (offer.Status == Status.YönetimBekleme && offer.AboveThreshold == false)
                {
                    offerManager.Add(offer);
                }
            }
            var mappedEntity = _mapper.Map<HashSet<OfferDto>>(offerManager);

            result.Data = mappedEntity;
            return result;
        }

        [Validator(typeof(GetOfferByIdValidator))]
        public async Task<Result<OfferDto>> GetOfferById(GetOfferByIdRM getOfferById)
        {
            var result = new Result<OfferDto>();

            var existEntity = await _unitWork.GetRepository<Offer>().GetSingleByFilterAsync(x => x.Id == getOfferById.Id, "Currency", "Supplier", "ApprovingEmployee");
            var mappedEntity = _mapper.Map<OfferDto>(existEntity);

            result.Data = mappedEntity;
            return result;
        }

        /// <summary>
        /// Durumu 'YönetimOnay olan teklifleri şirkete göre getirir.'
        /// </summary>
        /// <param name="company">Company.Id</param>
        /// <returns>Yönetim tarafından onaylanmış tekliflerin listesini döner.</returns>
        [Validator(typeof(GetOfferByIdValidator))]
        public Result<HashSet<OfferDto>> GetOfferByAproved(GetOfferByIdRM company)
        {
            var result = new Result<HashSet<OfferDto>>();
            var offerByCompany = GetOfferByCompany(company).Result.Data;
            HashSet<OfferDto> approvedOfferByCompany = new();
            foreach (var offer in offerByCompany)
            {
                if (offer.Status == Status.YönetimOnay)
                {
                    approvedOfferByCompany.Add(offer);
                }
            }
            var mappedEntity = _mapper.Map<HashSet<OfferDto>>(approvedOfferByCompany);
            result.Data = mappedEntity;
            return result;
        }

        /// <summary>
        /// Durumu 'FaturaEklendi' olan teklifleri şirkete göre getirir.
        /// </summary>
        /// <param name="company">Company.Id</param>
        /// <returns>Stok işlemi gerçekleştirilmiş tekliflerin listesini döner.</returns>
        [Validator(typeof(GetOfferByIdValidator))]
        public Result<HashSet<OfferDto>> GetOfferFromStock(GetOfferByIdRM company)
        {
            var result = new Result<HashSet<OfferDto>>();

            var offerByCompany = GetOfferByCompany(company).Result.Data;
            HashSet<OfferDto> offerFromStock = new();
            foreach (var offer in offerByCompany)
            {
                if (offer.Status == Status.FaturaEklendi)
                {
                    offerFromStock.Add(offer);
                }
            }
            var mappedEntity = _mapper.Map<HashSet<OfferDto>>(offerFromStock);

            result.Data = mappedEntity;
            return result;
        }
        #endregion
    }
}
