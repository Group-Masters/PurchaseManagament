using PurchaseManagament.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Domain.Entities
{
    // Para Birimi
    public class Currency:AuditableEntity
    {
        public string Name { get; set; }
        public double Rate { get; set; } // Kur oranı --> TL Karşılığı
        public virtual IEnumerable<Offer> Offers { get; set; }
    }
}
