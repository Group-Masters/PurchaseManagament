using AutoMapper;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Models.RequestModels.MaterialOffers;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Persistence.Abstract.UnitWork;
using System.Xml;
using static Microsoft.WindowsAPICodePack.Shell.PropertySystem.SystemProperties.System;

namespace PurchaseManagament.Application.Concrete.Services
{
    public class MaterialOfferService : IMaterialOfferService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;

        public MaterialOfferService(IMapper mapper, IUnitWork unitWork)
        {
            _mapper = mapper;
            _unitWork = unitWork;
        }

        #region MaterialOffer CRUD Operations
        public async Task<Result<long>> CreateMaterialOffer(CreateMaterialOfferRM createMaterialOfferRM)
        {
            var result = new Result<long>();

            var mappedEntity = _mapper.Map<MaterialOffer>(createMaterialOfferRM);
            _unitWork.GetRepository<MaterialOffer>().Add(mappedEntity);

            await _unitWork.CommitAsync();
            result.Data = mappedEntity.Id;
            return result;
        }

        public async Task<Result<long>> UpdateMaterialOffer(UpdateMaterialOfferRM updateMaterialOfferRM)
        {
            var result = new Result<long>();

            var entity = await _unitWork.GetRepository<MaterialOffer>().GetById(updateMaterialOfferRM);
            var mappedEntity = _mapper.Map(updateMaterialOfferRM, entity);
            _unitWork.GetRepository<MaterialOffer>().Update(mappedEntity);

            await _unitWork.CommitAsync();
            result.Data = mappedEntity.Id;
            return result;
        }

        public async Task<Result<bool>> DeleteMaterialOffer(GetByIdVM id)
        {
            var result = new Result<bool>();

            var entity = await _unitWork.GetRepository<MaterialOffer>().GetById(id.Id);
            entity.IsDeleted = true;
            _unitWork.GetRepository<MaterialOffer>().Update(entity);

            result.Data = await _unitWork.CommitAsync();
            return result;
        }

        public async Task<Result<bool>> DeleteMaterialOfferPermanent(GetByIdVM id)
        {
            var result = new Result<bool>();

            var entity = _unitWork.GetRepository<MaterialOffer>().GetById(id.Id);
            _unitWork.GetRepository<MaterialOffer>().Delete(await entity);

            result.Data = await _unitWork.CommitAsync();
            return result;
        }
        #endregion

        #region MaterialOffer Get Operations
        public async Task<Result<MaterialOfferDto>> GetMaterialOfferById(GetByIdVM getMaterialOfferById)
        {
            var result = new Result<MaterialOfferDto>();

            var entity = await _unitWork.GetRepository<MaterialOffer>().GetSingleByFilterAsync(x => x.Id == getMaterialOfferById.Id, "Material.Product.MeasuringUnit", "Offer.Currency", "Offer.Supplier");
            var mappedEntity = _mapper.Map<MaterialOfferDto>(entity);

            result.Data = mappedEntity;
            return result;
        }

        public async Task<Result<HashSet<MaterialOfferDto>>> GetMaterialOfferByOfferId(GetByIdVM getMaterialOfferByOfferIdRM)
        {
            var result = new Result<HashSet<MaterialOfferDto>>();

            var entity = await _unitWork.GetRepository<MaterialOffer>().GetByFilterAsync(x => x.OfferId == getMaterialOfferByOfferIdRM.Id, "Material.Product.MeasuringUnit", "Offer.Currency", "Offer.Supplier");
            var mappedEntity = _mapper.Map<HashSet<MaterialOfferDto>>(entity);

            result.Data = mappedEntity;
            return result;
        }

        public async Task<Result<HashSet<MaterialOfferDto>>> GetMaterialOfferByMaterialId(GetByIdVM getMaterialOfferByMaterialIdRM)
        {
            var result = new Result<HashSet<MaterialOfferDto>>();

            var entity = await _unitWork.GetRepository<MaterialOffer>().GetByFilterAsync(x => x.MaterialId== getMaterialOfferByMaterialIdRM.Id, "Material.Product.MeasuringUnit", "Offer.Currency", "Offer.Supplier");
            var mappedEntity = _mapper.Map<HashSet<MaterialOfferDto>>(entity);

            result.Data = mappedEntity;
            return result;
        }

        public async Task<Result<HashSet<MaterialOfferDto>>> GetMaterialOfferByRequestId(GetByIdVM getMaterialOfferByRequestIdRM)
        {
            var result = new Result<HashSet<MaterialOfferDto>>();

            var entity = await _unitWork.GetRepository<MaterialOffer>().GetByFilterAsync(x => x.Material.RequestId == getMaterialOfferByRequestIdRM.Id, "Material.Product.MeasuringUnit", "Offer.Currency", "Offer.Supplier");
            var mappedEntity = _mapper.Map<HashSet<MaterialOfferDto>>(entity);

            result.Data = mappedEntity;
            return result;
        }

        public async Task<Result<HashSet<MaterialOfferDto>>> GetAllMaterialOffer()
        {
            var result = new Result<HashSet<MaterialOfferDto>>();

            var entity = await _unitWork.GetRepository<MaterialOffer>().GetAllAsync("Material.Product.MeasuringUnit", "Offer.Currency", "Offer.Supplier");
            var mappedEntity = _mapper.Map<HashSet<MaterialOfferDto>>(entity);

            result.Data = mappedEntity;
            return result;
        }
        #endregion

        #region Offer Operations

        #endregion
    }
}
