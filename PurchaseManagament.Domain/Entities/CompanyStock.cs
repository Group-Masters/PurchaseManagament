﻿using PurchaseManagament.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Domain.Entities
{
    public class CompanyStock:AuditableEntity
    {
        public long CompanyId { get; set; }
        public long ProductId { get; set; }
        public double Quantity { get; set; }

        public virtual Company Company { get; set; }
        public virtual Product Product { get; set; }
        public virtual IEnumerable<StockOperations> StockOperations { get; set; }

    }
}
