using PurchaseManagament.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Concrete.Models.RequestModels.Invoices
{
    public class UpdateInvoiceStatusRM
    {
        public Int64 Id { get; set; }
        public Status Status { get; set; }
    }
}
