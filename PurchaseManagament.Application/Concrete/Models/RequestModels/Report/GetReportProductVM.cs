using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Concrete.Models.RequestModels.Report
{
    public class GetReportProductVM
    {
        public Int64 ProductId { get; set; }
        public Int64 CompanyId { get; set;}
    }
}
