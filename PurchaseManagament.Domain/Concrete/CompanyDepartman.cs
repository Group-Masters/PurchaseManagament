using PurchaseManagament.Domain.Abstract;
using PurchaseManagament.Domain.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Domain.Concrete
{
    // Şirket ve Departman
    public class CompanyDepartman : AuditableEntity
    {






        // Nav prop
        public long DepartmanID { get; set; }
        public long CompanyID { get; set;}
        public virtual Company Company { get; set; }
        public virtual Departman Departman { get; set; }
    }
}
