using PurchaseManagament.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Domain.Concrete.BaseEntities
{
    // Departman 
    public class Departman : AuditableEntity
    {
        public string Name { get; set; }


        // Nav Prop
        public virtual IEnumerable<CompanyDepartman> CompanyDepartmans { get; set; }

    }
}
