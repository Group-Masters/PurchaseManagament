﻿using PurchaseManagament.Domain.Common;
using PurchaseManagament.Domain.Enums;

namespace PurchaseManagament.Domain.Entities
{
    public class Request:AuditableEntity
    {  
        public long? ApprovingEmployeeId { get; set; }
        public long RequestEmployeeId { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string Description { get; set; }

        public virtual Employee ApprovedEmployee { get; set; } // Onaylayan 
        public virtual Employee RequestEmployee { get; set; } // Talep eden
        public IEnumerable<Material> Materials { get; set; }
        public virtual Status State { get; set; } // Durum
    }
}
