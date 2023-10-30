using PurchaseManagament.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Domain.Concrete.BaseEntities
{
    // Şirket
    public class Company : AuditableEntity
    {
        public string Name { get; set; }
        public string Adress { get; set; }

        // Nav Prop
        public IEnumerable<CompanyDepartman>  CompanyDepartmens { get; set; }

    }
}
