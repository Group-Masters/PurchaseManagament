using PurchaseManagament.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Domain.Entities
{
    public class Page:AuditableEntity
    {
        public Int64? UpperPageId { get; set; }
        public string Url { get; set; }
        public string PageName { get; set; }
        public string Content { get; set; }

        public virtual IEnumerable<PageRole> PageRoles { get; set; }
        public virtual Page? UpperPage { get; set; }
        public virtual IEnumerable<Page> LowerPages { get; set; }

    }
}
