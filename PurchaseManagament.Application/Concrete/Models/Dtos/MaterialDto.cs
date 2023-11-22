namespace PurchaseManagament.Application.Concrete.Models.Dtos
{
    public class MaterialDto
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public double Quantity { get; set; }
        public string MeasuringUnit { get; set; }
        public long RequestId { get; set; }
        public string Details { get; set; }
    }
}
