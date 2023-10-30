﻿using PurchaseManagament.Domain.Common;

namespace PurchaseManagament.Domain.Entities
{
    public class Invoice:AuditableEntity
    {
        public long OfferId { get; set; }
        public Guid UUID { get; set; }
        public virtual Offer Offer { get; set; }
    }
}
