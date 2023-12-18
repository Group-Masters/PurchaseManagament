using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Concrete.Models.RequestModels.Pages
{
    public class PageAddRoleVM
    {
        public Int64 PageId { get; set; }
        public Int64 RoleId { get; set; }
        //public bool Reading { get; set; }
        public bool Deleting { get; set; }
        public bool Updating { get; set; }
        public bool Creating { get; set; }
    }
}
