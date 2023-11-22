namespace PurchaseManagament.Application.Concrete.Models.RequestModels.Materials
{
    public class CreateMaterialRM
    {
        public long RequestId { get; set; }
        public long ProductId { get; set; }
        public string Details { get; set; }
        public double Quantity { get; set; }
    }
}
