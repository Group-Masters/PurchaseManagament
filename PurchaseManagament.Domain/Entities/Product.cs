using PurchaseManagament.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Domain.Entities
{
    public class Product:AuditableEntity
    {
        public long MeasuringUnitId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public MeasuringUnit MeasuringUnit { get; set; }
        public CompanyStock CompanyStock { get; set; }
        public IEnumerable<Request> Requests { get; set; }
        public IEnumerable<StockOperations> StockOperations { get; set; }

    }
}
