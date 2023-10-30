using PurchaseManagament.Domain.Abstract;
using PurchaseManagament.Domain.Concrete.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Domain.Concrete
{
    // Şirket Stok
    public class CompanyStock : AuditableEntity
    {
        public string ProductUnitType { get; set; }
        public double Quantity { get; set; }



        // Nav Prop
        public virtual Company Company { get; set; }
        public long CompanyID { get; set; }
        public virtual Product Product { get; set; }
        public long ProductId { get; set; }


    }

}
