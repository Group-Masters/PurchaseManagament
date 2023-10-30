using PurchaseManagament.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Domain.Entities
{
    public class EmployeeDetail:AuditableEntity
    {
        public long EmployeeId { get; set; }
        public bool? EmailOk { get; set; }
        public string? ApprovedCode { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
