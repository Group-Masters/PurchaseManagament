namespace PurchaseManagament.Application.Concrete.Models.Dtos
{
    public class CurrencyDTO
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public double Rate { get; set; } // Kur oranı --> TL Karşılığı
    }
}
