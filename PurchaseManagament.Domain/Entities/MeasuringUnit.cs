﻿using PurchaseManagament.Domain.Common;

namespace PurchaseManagament.Domain.Entities
{
    public class MeasuringUnit:AuditableEntity
    {
        public string Name { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
    }
}
