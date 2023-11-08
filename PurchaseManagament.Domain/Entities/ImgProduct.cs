using PurchaseManagament.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Domain.Entities
{
    public class ImgProduct : AuditableEntity
    {

        public Int64 ProductId { get; set; }
        public string ImageSrc { get; set; }

        //nav
        public virtual Product Product { get; set; }
    }
}
