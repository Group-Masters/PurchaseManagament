using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyStocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyStocks
{
    public class UpdateCompanyQuantityReduceRM
    {
        public Int64 Id { get; set; }
      
        public long CompanyDepartmentId { get; set; }
        public double Quantity { get; set; }
    
    
    }
}
