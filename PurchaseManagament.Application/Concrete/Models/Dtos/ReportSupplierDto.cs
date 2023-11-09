using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Concrete.Models.Dtos
{
    public class ReportSupplierDto
    {
        public string SupplierName { get; set; }
        public Int64 OfferId { get; set; }
        public string CreateDate { get; set; }
        public Status Status { get; set; }
        public string Price { get; set; }
        public string Detail { get; set; }
        public string Product { get; set; }
        public string Quantity { get; set; }
    }
}
