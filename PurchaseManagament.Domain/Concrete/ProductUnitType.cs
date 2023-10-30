using PurchaseManagament.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Domain.Concrete
{
    // Adet/Birim Tip
    public class ProductUnitType : AuditableEntity
    {
        public string TypeName { get; set; }



        // Nav Prop
        public virtual IEnumerable<Product> Products { get; set; }
    }
}
