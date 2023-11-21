using PurchaseManagament.Domain.Common;

namespace PurchaseManagament.Domain.Entities
{
    public class Product:AuditableEntity
    {
        public long MeasuringUnitId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual MeasuringUnit MeasuringUnit { get; set; }
        public virtual IEnumerable<CompanyStock> CompanyStocks { get; set; }
        public virtual IEnumerable<Request> Requests { get; set; }
        public virtual IEnumerable<Material> Materials { get; set; }
        public virtual ImgProduct ImgProduct { get; set; }

    }
}
