﻿namespace PurchaseManagament.Application.Concrete.Models.RequestModels.MaterialOffers
{
    public class CreateMaterialOfferRM
    {
        public long OfferId { get; set; }
        public long MaterialId { get; set; }
        public double OfferedPrice { get; set; }
    }
}
