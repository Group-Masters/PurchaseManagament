using PurchaseManagament.Domain.Common;

namespace PurchaseManagament.Domain.Entities
{
    // Ürün Birim Tip
    public class MeasuringUnit : BaseEntity
    {
        public string Name { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
    }
}
