using PurchaseManagament.Domain.Common;

namespace PurchaseManagament.Domain.Entities
{
    public class Product : BaseEntity
    {
        public long MeasuringUnitId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual MeasuringUnit MeasuringUnit { get; set; }
        public virtual IEnumerable<CompanyStock> CompanyStocks { get; set; }
        public virtual IEnumerable<Request> Requests { get; set; }
        public virtual IEnumerable<StockOperations> StockOperations { get; set; }


    }
}
