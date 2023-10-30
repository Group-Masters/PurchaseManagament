using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Domain.Abstract
{
    public class AuditableEntity : BaseEntity
    {
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? CreatedIP4 { get; set; }
        public long? CreatedById { get; set; }
        public long? ModifiedById { get; set; }
        public string? ModifiedIP4 { get; set; }

    }
}
