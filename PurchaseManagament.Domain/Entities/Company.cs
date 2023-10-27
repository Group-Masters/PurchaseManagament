using PurchaseManagament.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Domain.Entities
{
    public class Company:AuditableEntity
    {
        public string  Name { get; set; }
        public IEnumerable<CompanyDepartment> CompanyDepartments { get; set; }
        public IEnumerable<CompanyStock> CompanyStocks { get; set; }

    }
}
