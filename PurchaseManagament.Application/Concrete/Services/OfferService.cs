﻿using AutoMapper;
using Microsoft.IdentityModel.Tokens.Saml2;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Attributes;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Offers;
using PurchaseManagament.Application.Concrete.Validators.Offer;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Domain.Abstract;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Domain.Enums;
using PurchaseManagament.Persistence.Abstract.UnitWork;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PurchaseManagament.Application.Concrete.Services
{
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

        public async Task<Result<long>> CreateOffer(CreateOfferRM create)
        {
            var result = new Result<long>();
            var mappedEntity = _mapper.Map<Offer>(create);
            _unitWork.GetRepository<Offer>().Add(mappedEntity);
            await _unitWork.CommitAsync();
            result.Data = mappedEntity.Id;
            return result;
        }

        public async Task<Result<bool>> DeleteOffer(long id)
        {
            var result = new Result<bool>();
            var entity = await _unitWork.GetRepository<Offer>().GetById(id);
            if (entity is null)
            {
                throw new Exception($"{id}'li teklif bulunamamıştır.");
            }
            entity.IsDeleted = true;
            _unitWork.GetRepository<Offer>().Update(entity);
            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        public async Task<Result<bool>> DeleteOfferPermanent(long id)
        {
            var result = new Result<bool>();
            var entity = _unitWork.GetRepository<Offer>().GetById(id);
            if (entity is null)
            {
                throw new Exception($"{id}'li teklif bulunamamıştır.");
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

        public async Task<Result<HashSet<OfferDto>>> GetAllOfferByRequestId(GetOfferByIdRM getOfferByRequestId)
        {
            var result = new Result<HashSet<OfferDto>>();
            var entities = await _unitWork.GetRepository<Offer>().GetByFilterAsync(x => x.RequestId == getOfferByRequestId.Id, "Currency", "Supplier", "ApprovingEmployee","Request.Product");
            var mappedEntity = _mapper.Map<HashSet<OfferDto>>(entities);
            result.Data = mappedEntity;
            return result;
        }

        public async Task<Result<HashSet<OfferDto>>> GetOfferByChairman(GetOfferByIdRM company)
        {
            var result = new Result<HashSet<OfferDto>>();
            var entities = await _unitWork.GetRepository<Offer>().GetByFilterAsync(x => x.Request.RequestEmployee.CompanyDepartment.CompanyId == company.Id && x.Status == Status.YönetimBekleme && x.OfferedPrice >= 20000
            , "Currency", "Supplier", "ApprovingEmployee.CompanyDepartment.Company", "Request.Product.MeasuringUnit", "Request.RequestEmployee.CompanyDepartment.Company");
            var mappedEntity = _mapper.Map<HashSet<OfferDto>>(entities);
            result.Data = mappedEntity;
            return result;
        }

        public async Task<Result<HashSet<OfferDto>>> GetOfferByManager(GetOfferByIdRM company)
        {
            var result = new Result<HashSet<OfferDto>>();
            var entities = await _unitWork.GetRepository<Offer>().GetByFilterAsync(x => x.Request.RequestEmployee.CompanyDepartment.CompanyId == company.Id && x.Status == Status.YönetimBekleme && x.OfferedPrice <= 20000
            , "Currency", "Supplier", "ApprovingEmployee.CompanyDepartment.Company", "Request.Product.MeasuringUnit", "Request.RequestEmployee.CompanyDepartment.Company");
            var mappedEntity = _mapper.Map<HashSet<OfferDto>>(entities);
            result.Data = mappedEntity;
            return result;
        }

        public async Task<Result<OfferDto>> GetOfferById(GetOfferByIdRM getOfferById)
        {
            var result = new Result<OfferDto>();
            var entityControl = await _unitWork.GetRepository<Offer>().AnyAsync(x => x.Id == getOfferById.Id);
            if (!entityControl)
            {
                throw new Exception($"{getOfferById.Id}'li teklif bulunamamıştır.");
            }

            var existEntity = await _unitWork.GetRepository<Offer>().GetSingleByFilterAsync(x => x.Id == getOfferById.Id, "Currency", "Supplier", "ApprovingEmployee");
            var mappedEntity = _mapper.Map<OfferDto>(existEntity);
            result.Data = mappedEntity;
            return result;
        }


        public async Task<Result<long>> UpdateOffer(UpdateOfferRM update)
        {
            var result = new Result<long>();
            var entity = await _unitWork.GetRepository<Offer>().GetById(update.Id);
            if (entity is null)
            {
                throw new Exception($"{update.Id}'li teklif bulunamamıştır.");
            }
            _mapper.Map(update, entity);
            _unitWork.GetRepository<Offer>().Update(entity);
            await _unitWork.CommitAsync();
            result.Data = entity.Id;
            return result;
        }

        //[Validator(typeof(UpdateOfferStateValidator))]
        public async Task<Result<long>> UpdateOfferState(UpdateOfferStateRM update)
        {
            var result = new Result<long>();
            var entity = await _unitWork.GetRepository<Offer>().GetSingleByFilterAsync(x=>x.Id==update.Id, "Supplier");
            if (entity is null)
            {
                throw new Exception("Teklif güncellemesi için id eşleşmesi başarısız oldu.");
            }
            if(update.Status==Status.YönetimBekleme)
            {
              var requestEntity= await _unitWork.GetRepository<Request>().GetById(entity.RequestId);
                requestEntity.State = update.Status;
                _unitWork.GetRepository<Request>().Update(requestEntity);
            }
            else if (update.Status==Status.YönetimOnay)
            {
                var requestEntity = await _unitWork.GetRepository<Request>().GetById(entity.RequestId);
                requestEntity.State = update.Status;
                _unitWork.GetRepository<Request>().Update(requestEntity);
            }
            else if (update.Status == Status.YönetimRed)
            {
                var requestEntity = await _unitWork.GetRepository<Request>().GetById(entity.RequestId);
                requestEntity.State = update.Status;
                _unitWork.GetRepository<Request>().Update(requestEntity);

            }else if(update.Status==Status.FaturaEklendi)
            {
                var requestEntity = await _unitWork.GetRepository<Request>().GetById(entity.RequestId);
                requestEntity.State = update.Status;
                _unitWork.GetRepository<Request>().Update(requestEntity);
            }else if (entity.SupplierId == 1)
            {
                var requestEntity = await _unitWork.GetRepository<Request>().GetById(entity.RequestId);
                requestEntity.State = Status.FaturaEklendi;

                _unitWork.GetRepository<Request>().Update(requestEntity);
                update.Status= Status.FaturaEklendi;
            }
           


            _mapper.Map(update, entity);
            entity.ApprovingEmployeeId =(Int64)_loggedService.UserId;
            _unitWork.GetRepository<Offer>().Update(entity);
            await _unitWork.CommitAsync();
            result.Data = entity.Id;
            return result;
        }

        public async Task<Result<HashSet<OfferDto>>> GetOfferByAproved(GetOfferByIdRM company)
        {
            var result = new Result<HashSet<OfferDto>>();
            var entities = await _unitWork.GetRepository<Offer>().GetByFilterAsync(x => x.Request.RequestEmployee.CompanyDepartment.CompanyId == company.Id && x.Status == Status.YönetimOnay 
            , "Currency", "Supplier", "ApprovingEmployee.CompanyDepartment.Company", "Request.Product.MeasuringUnit", "Request.RequestEmployee.CompanyDepartment.Company");
            var mappedEntity = _mapper.Map<HashSet<OfferDto>>(entities);
            result.Data = mappedEntity;
            return result;
        }
    }
}
