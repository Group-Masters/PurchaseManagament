namespace PurchaseManagament.Application.Concrete.Models.RequestModels.Products
{
    public class CreateProductRM
    {
        public long MeasuringUnitId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
    }
}
