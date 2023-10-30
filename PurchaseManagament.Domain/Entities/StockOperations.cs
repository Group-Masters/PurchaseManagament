﻿using PurchaseManagament.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Domain.Entities
{
    public class StockOperations:AuditableEntity
    {
        public long CompanyStockId { get; set; }
        public long ReceiverEmployeeId { get; set; }
        public long ProductId { get; set; }
        public double Quantity { get; set; }

        public virtual CompanyStock CompanyStock { get; set; }
        public virtual Product Product { get; set; }

        public virtual Employee ReceiverEmployee { get; set; }

    }

}
