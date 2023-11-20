using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
using System.Xml;

namespace PurchaseManagament.Application.Concrete.Services
{
    [NullCheckParam]
    public class OfferService : IOfferService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;
        private readonly ILoggedService _loggedService;

        public OfferService(IMapper mapper, IUnitWork unitWork, ILoggedService loggedService)
        {
            _mapper = mapper;
            _unitWork = unitWork;
            _loggedService = loggedService;
        }

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

        public async Task<Result<HashSet<OfferDto>>> GetAllOffer()
        {
            var result = new Result<HashSet<OfferDto>>();
            var entities = await _unitWork.GetRepository<Offer>().GetAllAsync("Currency", "Supplier", "ApprovingEmployee");
            var mappedEntity = _mapper.Map<HashSet<OfferDto>>(entities);
            result.Data = mappedEntity;
            return result;
        }

        [Validator(typeof(GetOfferByIdValidator))]
        public async Task<Result<HashSet<OfferDto>>> GetAllOfferByRequestId(GetOfferByIdRM getOfferByRequestId)
        {
            var result = new Result<HashSet<OfferDto>>();
            var entities = await _unitWork.GetRepository<Offer>().GetByFilterAsync(x => x.RequestId == getOfferByRequestId.Id, "Currency", "Supplier", "ApprovingEmployee", "Request.Product");
            var mappedEntity = _mapper.Map<HashSet<OfferDto>>(entities);
            result.Data = mappedEntity;
            return result;
        }

        [Validator(typeof(GetOfferByIdValidator))]
        public async Task<Result<HashSet<OfferDto>>> GetOfferByChairman(GetOfferByIdRM company)
        {
            XmlDocument xmlVerisi = new XmlDocument();
            xmlVerisi.Load("https://www.tcmb.gov.tr/kurlar/today.xml");
            //decimal usd = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "USD")).InnerText.Replace('.', ','));
            //decimal eur = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "EUR")).InnerText.Replace('.', ','));
            //decimal jpy = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "JPY")).InnerText.Replace('.', ','));

            var result = new Result<HashSet<OfferDto>>();
            var entities = await _unitWork.GetRepository<Offer>().GetByFilterAsync(x => x.Request.RequestEmployee.CompanyDepartment.CompanyId == company.Id && x.Status == Status.YönetimBekleme
            , "Currency", "Supplier", "ApprovingEmployee.CompanyDepartment.Company", "Request.Product.MeasuringUnit", "Request.RequestEmployee.CompanyDepartment.Company");

            var list = new HashSet<Offer>();

          
            foreach (var entity in entities)
            {
                var managerThreshold = entity.Request.RequestEmployee.CompanyDepartment.Company.ManagerThreshold;
                if (entity.Currency.Name=="TRY")
                {
                    if (entity.OfferedPrice> managerThreshold)
                    {
                        list.Add(entity);
                    }
                    continue;
                }
                var rate = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", $"{entity.Currency.Name}")).InnerText.Replace('.', ','));
                
                if (rate * entity.OfferedPrice > managerThreshold)
                {
                    list.Add(entity);
                }

            }



            var mappedEntity = _mapper.Map<HashSet<OfferDto>>(list);
            result.Data = mappedEntity;
            return result;
        }

        [Validator(typeof(GetOfferByIdValidator))]
        public async Task<Result<HashSet<OfferDto>>> GetOfferByManager(GetOfferByIdRM company)
        {

            XmlDocument xmlVerisi = new XmlDocument();
            xmlVerisi.Load("https://www.tcmb.gov.tr/kurlar/today.xml");
            var result = new Result<HashSet<OfferDto>>();
            var entities = await _unitWork.GetRepository<Offer>().GetByFilterAsync(x => x.Request.RequestEmployee.CompanyDepartment.CompanyId == company.Id && x.Status == Status.YönetimBekleme
            , "Currency", "Supplier", "ApprovingEmployee.CompanyDepartment.Company", "Request.Product.MeasuringUnit", "Request.RequestEmployee.CompanyDepartment.Company");

            var list = new HashSet<Offer>();
            foreach (var entity in entities)
            {
                var managerThreshold = entity.Request.RequestEmployee.CompanyDepartment.Company.ManagerThreshold;
                if (entity.Currency.Name == "TRY")
                {
                    if (entity.OfferedPrice <= managerThreshold)
                    {
                        list.Add(entity);
                    }
                    continue;
                }
                var rate = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", $"{entity.Currency.Name}")).InnerText.Replace('.', ','));

                if (rate * entity.OfferedPrice <= managerThreshold)
                {
                    list.Add(entity);
                }

            }



            var mappedEntity = _mapper.Map<HashSet<OfferDto>>(list);
            result.Data = mappedEntity;
            return result;
        }

        [Validator(typeof(GetOfferByIdValidator))]
        public async Task<Result<OfferDto>> GetOfferById(GetOfferByIdRM getOfferById)
        {
            var result = new Result<OfferDto>();
            var entityControl = await _unitWork.GetRepository<Offer>().AnyAsync(x => x.Id == getOfferById.Id);
            if (!entityControl)
            {
                throw new NotFoundException("İstenen Teklif kaydı bulunamadı.");
            }

            var existEntity = await _unitWork.GetRepository<Offer>().GetSingleByFilterAsync(x => x.Id == getOfferById.Id, "Currency", "Supplier", "ApprovingEmployee");
            var mappedEntity = _mapper.Map<OfferDto>(existEntity);
            result.Data = mappedEntity;
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
            var entity = await _unitWork.GetRepository<Offer>().GetSingleByFilterAsync(x => x.Id == update.Id, "Supplier");
            if (entity is null)
            {
                throw new NotFoundException("Güncellenmek istenen Teklif kaydı bulunamadı.");
            }

            //talebin tedarikçisi  stoksa ve yönetim onaya gönderilecekse
            if (entity.SupplierId == 1 && update.Status == Status.YönetimOnay)
            {
                var requestEntity = await _unitWork.GetRepository<Request>().GetById(entity.RequestId);
                requestEntity.State = Status.FaturaEklendi;

                _unitWork.GetRepository<Request>().Update(requestEntity);
                update.Status = Status.FaturaEklendi;
            }
            else if (update.Status == Status.YönetimBekleme)
            {
                var requestEntity = await _unitWork.GetRepository<Request>().GetById(entity.RequestId);
                requestEntity.State = update.Status;
                _unitWork.GetRepository<Request>().Update(requestEntity);

                var offers = await _unitWork.GetRepository<Offer>().GetByFilterAsync(x => x.Id != entity.Id && x.RequestId == entity.RequestId);
                foreach (var item in offers)
                {
                    item.Status = Status.Reddedildi;
                    _unitWork.GetRepository<Offer>().Update(item);
                }
            }
            else if (update.Status == Status.YönetimOnay || update.Status == Status.YönetimRed || update.Status == Status.FaturaEklendi || update.Status == Status.Tamamlandı)
            {
                var requestEntity = await _unitWork.GetRepository<Request>().GetById(entity.RequestId);
                requestEntity.State = update.Status;
                _unitWork.GetRepository<Request>().Update(requestEntity);
            }

            _mapper.Map(update, entity);
            entity.ApprovingEmployeeId = (Int64)_loggedService.UserId;
            _unitWork.GetRepository<Offer>().Update(entity);
            await _unitWork.CommitAsync();
            result.Data = entity.Id;
            return result;
        }

        [Validator(typeof(GetOfferByIdValidator))]
        public async Task<Result<HashSet<OfferDto>>> GetOfferByAproved(GetOfferByIdRM company)
        {
            var result = new Result<HashSet<OfferDto>>();
            var entities = await _unitWork.GetRepository<Offer>().GetByFilterAsync(x => x.Request.RequestEmployee.CompanyDepartment.CompanyId == company.Id && x.Status == Status.YönetimOnay
            , "Currency", "Supplier", "ApprovingEmployee.CompanyDepartment.Company", "Request.Product.MeasuringUnit", "Request.RequestEmployee.CompanyDepartment.Company");
            var mappedEntity = _mapper.Map<HashSet<OfferDto>>(entities);
            result.Data = mappedEntity;
            return result;
        }

        [Validator(typeof(GetOfferByIdValidator))]
        public async Task<Result<HashSet<OfferDto>>> GetOfferFromStock(GetOfferByIdRM company)
        {
            var result = new Result<HashSet<OfferDto>>();

            var entities = await _unitWork.GetRepository<Offer>().GetByFilterAsync(x => x.Request.RequestEmployee.CompanyDepartment.CompanyId == company.Id &&
            x.Status == Status.FaturaEklendi && x.SupplierId == 1
            , "Currency", "Supplier", "ApprovingEmployee.CompanyDepartment.Company", "Request.Product.MeasuringUnit", "Request.RequestEmployee.CompanyDepartment.Company");
            var mappedEntity = _mapper.Map<HashSet<OfferDto>>(entities);

            result.Data = mappedEntity;
            return result;
        }
    }
}
