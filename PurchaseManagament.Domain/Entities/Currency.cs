using PurchaseManagament.Domain.Common;
using PurchaseManagament.Persistence.Concrete.Audits;

namespace PurchaseManagament.Domain.Entities
{
    // Para Birimi
    public class Currency : BaseEntity
    {
        [NotAuditable]
        public string Name { get; set; }

        [NotAuditable]
        public double Rate { get; set; } // Kur oranı --> TL Karşılığı
        public virtual IEnumerable<Offer> Offers { get; set; }
    }
}
