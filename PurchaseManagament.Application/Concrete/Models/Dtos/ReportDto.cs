using PurchaseManagament.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Concrete.Models.Dtos
{
    public class ReportDto
    {
        public Int64 RequestId { get; set; }
        public Status Status { get; set; }
        public string Requestby { get; set; }
        public string Companydepartment { get; set; }
        public string product { get; set; }
        public string Quantity { get; set; }
        public string CreateDate { get; set; }
        public string? ApprovedEmployee { get; set; }
        public string? Prices { get; set; }
        public string? supplier { get; set; }
        public string? supplyDate { get; set;}
        public Int64? InvoiceId { get; set; }

    }
}
