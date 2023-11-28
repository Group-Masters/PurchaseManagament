using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Concrete.Models.RequestModels.Invoices
{
    public class UpdateInvoiceImageVM
    {
        public long Id { get; set; }
        public string ImageString { get; set; }
    }
}
