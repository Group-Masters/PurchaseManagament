using PurchaseManagament.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Domain.Entities
{
    public class EmployeeRole:AuditableEntity
    {
        public long EmployeeId { get; set; }
        public long RoleId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Role Role { get; set; }
    }
}
