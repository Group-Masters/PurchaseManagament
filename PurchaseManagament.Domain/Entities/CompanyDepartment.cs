using PurchaseManagament.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Domain.Entities
{
    public class CompanyDepartment:AuditableEntity
    {
        public long CompanyId { get; set; }
        public long DepartmentId { get; set; }
        public virtual Company Company { get; set; }
        public virtual Department Department { get; set; }
    }
}
