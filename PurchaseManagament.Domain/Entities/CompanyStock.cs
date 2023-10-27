using PurchaseManagament.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Domain.Entities
{
    public class CompanyStock:AuditableEntity
    {
        public long CompanyId { get; set; }
        public long ProductId { get; set; }
        public double Quantity { get; set; }

        public Company Company { get; set; }
        public Product Product { get; set; }

    }
}
