using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Domain.Abstract
{
    public class BaseEntity
    {
        public long ID { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }

    }
}
