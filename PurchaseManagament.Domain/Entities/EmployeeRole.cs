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
        public Employee Employee { get; set; }
        public Role Role { get; set; }
    }
}
