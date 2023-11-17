using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Concrete.Models.Dtos
{
    public class OfferReportDto
    {
        public Int64 offerId { get; set; }
        public string OfferPrice { get; set; }
        public string Supplier { get; set; }
        public string OfferDetail { get; set; }
        public string CreateDate { get; set; }
        public string ApprovingBy { get; set; }
        public string Status { get; set; }  


    }
}
