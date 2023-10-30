using PurchaseManagament.Domain.Common;
using PurchaseManagament.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Domain.Entities
{
    public class Offer:AuditableEntity
    {
        public long CurrencyId { get; set; }
        public long SupplierId { get; set; }
        public long RequestId { get; set; }
        public long ApprovingEmployeeId { get; set; }
        public decimal OfferedPrice { get; set; }
        public string Details { get; set; }

        public virtual Currency Currency { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Request Request { get; set; }
        public virtual Employee ApprovingEmployee { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual Status State { get; set; } // Durum
    }
}
