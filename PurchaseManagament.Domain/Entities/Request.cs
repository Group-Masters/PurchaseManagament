using PurchaseManagament.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Domain.Entities
{
    public class Request:AuditableEntity
    {
        public long ProductId { get; set; }
        public long StatusId { get; set; }
        public long approvingEmployeeId { get; set; }
        public string Details { get; set; }
        public double Quantity { get; set; }

        public Product Product { get; set; }
        public Status Status { get; set; }
        public Employee ApprovedEmployee { get; set; }
        public IEnumerable<Offer> Offers { get; set; }
    }
}
