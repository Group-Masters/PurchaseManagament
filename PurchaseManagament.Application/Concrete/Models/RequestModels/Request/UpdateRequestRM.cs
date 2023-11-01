using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Concrete.Models.RequestModels.Request
{
    public class UpdateRequestRM
    {
        public Int64 Id { get; set; }
        public long ProductId { get; set; }
        public string Details { get; set; }
        public double Quantity { get; set; }
    }
}
