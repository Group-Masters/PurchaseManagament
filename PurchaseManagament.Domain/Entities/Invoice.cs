﻿using PurchaseManagament.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Domain.Entities
{
    // Fatura
    public class Invoice:AuditableEntity
    {
        public long OfferId { get; set; }
        public Guid UuId { get; set; }
        public virtual Offer Offer { get; set; }
    }
}
