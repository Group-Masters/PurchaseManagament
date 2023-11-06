namespace PurchaseManagament.Application.Concrete.Models.RequestModels.Products
{
    public class UpdateProductRM
    {
        public long Id { get; set; }
        public long MeasuringUnitId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
