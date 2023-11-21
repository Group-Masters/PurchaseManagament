namespace PurchaseManagament.Application.Concrete.Models.Dtos
{
    public class MaterialDto
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long RequestId { get; set; }
        public string Details { get; set; }
        public double Quantity { get; set; }
    }
}
