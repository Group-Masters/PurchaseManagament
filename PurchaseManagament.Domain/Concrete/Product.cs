using PurchaseManagament.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Domain.Concrete
{
    public class Product : AuditableEntity
    {

        public string Name { get; set; }
        public string Description { get; set; }



        // Nav Prop
        public virtual ProductUnitType ProductUnitType { get; set; } // Ürün Tip
        public long ProductUnitTypeID { get; set; }

    }
}
