using PurchaseManagament.Domain.Common;
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
        public long StatusId { get; set; }
        public decimal OfferedPrice { get; set; }
        public string Details { get; set; }

        public Currency Currency { get; set; }
        public Supplier Supplier { get; set; }
        public Request Request { get; set; }
        public Employee ApprovingEmployee { get; set; }
        public Status Status { get; set; }
        public Offer offer { get; set; }
    }
}
