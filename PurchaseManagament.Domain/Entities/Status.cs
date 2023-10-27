using PurchaseManagament.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Domain.Entities
{
    public class Status:AuditableEntity

    {
        public string StatusName { get; set; }

        public IEnumerable<Request> Requests { get; set; }
        public IEnumerable<Offer> Offers { get; set; }

    }
}
