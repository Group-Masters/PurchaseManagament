using PurchaseManagament.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Domain.Entities
{
    public class Currency:AuditableEntity
    {
        public string Name { get; set; }
        public IEnumerable<Offer> Offers { get; set; }
    }
}
