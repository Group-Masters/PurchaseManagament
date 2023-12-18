using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Concrete.Models.RequestModels.Pages
{
    public class CreatePageVM
    {
        public Int64? UpperPageId { get; set; }
        public string Url { get; set; }
        public string PageName { get; set; }
    }
}
