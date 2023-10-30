using PurchaseManagament.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Domain.Common
{
    public class AuditableEntity:BaseEntity
    {
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
      
        public string CreatedIP { get; set; }
        public long CreatedById { get; set; }
        public long? ModifiedById { get; set; }
        public string? ModifiedIP { get; set; }
        public string CreatedByNameSurname { get; set; }
        public string? ModifiedByNameSurname { get; set; }
        

    }
}
