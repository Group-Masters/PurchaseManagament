using PurchaseManagament.Domain.Common;

namespace PurchaseManagament.Domain.Entities
{
    // Para Birimi
    public class Currency : BaseEntity
    {
        public string Name { get; set; }
        public double Rate { get; set; } // Kur oranı --> TL Karşılığı
        public virtual IEnumerable<Offer> Offers { get; set; }
    }
}
