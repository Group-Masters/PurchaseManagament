using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Concrete.Models.RequestModels.Currency
{
    public class UpdateCurrencyRM
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public double Rate { get; set; } // Kur oranı --> TL Karşılığı
    }
}
