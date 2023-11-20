using AutoMapper;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Attributes;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Currency;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Validators.Currencies;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Application.Exceptions;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Persistence.Abstract.UnitWork;
using System.Xml;

namespace PurchaseManagament.Application.Concrete.Services
{
    [NullCheckParam]
    public class CurrencyService : ICurrencyService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;
        public CurrencyService(IMapper mapper, IUnitWork unitWork)
        {
            _mapper = mapper;
            _unitWork = unitWork;
        }

        [Validator(typeof(CreateCurrencyValidator))]
        public async Task<Result<long>> CreateCurrency(CreateCurrencyRM createCurrencyRM)
        {
            var result = new Result<long>();

            var currencyExists = await _unitWork.GetRepository<Currency>().AnyAsync(x => x.Name == createCurrencyRM.Name);
            if (currencyExists)
            {
                throw new AlreadyExistsException("Bu isimde bir Para Birimi kaydı zaten bulunmakta.");
            }

            var mappedEntity = _mapper.Map<Currency>(createCurrencyRM);
            _unitWork.GetRepository<Currency>().Add(mappedEntity);
            await _unitWork.CommitAsync();
            result.Data = mappedEntity.Id;
            return result;
        }

        [Validator(typeof(GetByIdCurrencyValidator))]
        public async Task<Result<bool>> DeleteCurrency(GetByIdVM id)
        {
            var result = new Result<bool>();
            var entity = await _unitWork.GetRepository<Currency>().GetById(id.Id);
            if (entity is null)
            {
                throw new NotFoundException("Silinmek istenen Para Birimi kaydı bulunamadı.");
            }
            entity.IsDeleted = true;
            _unitWork.GetRepository<Currency>().Update(entity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        [Validator(typeof(GetByIdCurrencyValidator))]
        public async Task<Result<bool>> DeleteCurrencyPermanent(GetByIdVM id)
        {
            var result = new Result<bool>();
            var entity = _unitWork.GetRepository<Currency>().GetById(id.Id);
            if (entity is null)
            {
                throw new NotFoundException("Silinmek istenen Para Birimi kaydı bulunamadı.");
            }
            _unitWork.GetRepository<Currency>().Delete(await entity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        public async Task<Result<HashSet<CurrencyDTO>>> GetAllCurrency()
        {
            var result = new Result<HashSet<CurrencyDTO>>();
            XmlDocument xmlVerisi = new XmlDocument();
            xmlVerisi.Load("https://www.tcmb.gov.tr/kurlar/today.xml");
            var entities = _unitWork.GetRepository<Currency>().GetAllAsync();
            var mappedEntities = _mapper.Map<HashSet<CurrencyDTO>>(await entities);
            foreach ( var entity in mappedEntities)
            {
                if (entity.Name=="TRY" )
                {
                    entity.Rate = 1;
                    continue;
                }
                entity.Rate = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", $"{entity.Name}")).InnerText.Replace('.', ','));
            }
            result.Data = mappedEntities;
            return result;
        }

        public Result<HashSet<CurrencyNamesDto>> GetAllCurrencyNames()
        {
            var result = new Result<HashSet<CurrencyNamesDto>>();
            var xml = new XmlDocument();
            xml.Load("https://www.tcmb.gov.tr/kurlar/today.xml");
            
            var deneme = xml.DocumentElement?.ChildNodes;
            var list = new HashSet<CurrencyNamesDto>();
            foreach (XmlNode item in deneme)
            {
               list.Add(new CurrencyNamesDto() { Name = item.ChildNodes.Item(1).InnerText, Code = item.Attributes["Kod"].InnerText });
               //Console.WriteLine(item.Attributes["Kod"].InnerText);
               //Console.WriteLine(item.ChildNodes.Item(1).InnerText);
            }
            result.Data = list;
            
            return result;
        }

        [Validator(typeof(UpdateCurrencyValidator))]
        public async Task<Result<long>> UpdateCurrency(UpdateCurrencyRM updateCurrencyRM)
        {
            var result = new Result<long>();
            var entity = await _unitWork.GetRepository<Currency>().GetById(updateCurrencyRM.Id);
            if (entity is null)
            {
                throw new NotFoundException("Güncellenmek istenen Para Birimi kaydı bulunamadı.");
            }
            var mappedEntity = _mapper.Map(updateCurrencyRM, entity);
            _unitWork.GetRepository<Currency>().Update(mappedEntity);
            await _unitWork.CommitAsync();
            result.Data = entity.Id;
            return result;
        }
    }
}
