using PurchaseManagament.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Domain.Entities
{
    public class Supplier:AuditableEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual IEnumerable<Offer> Offers { get; set; }
    }
}
