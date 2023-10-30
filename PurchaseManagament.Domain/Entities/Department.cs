using PurchaseManagament.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Domain.Entities
{
    // Departman
    public class Department:AuditableEntity
    {
        public string Name { get; set; }
        public virtual IEnumerable<CompanyDepartment> CompanyDepartments { get; set; } // Şirket ve Departman
    }
}
