namespace PurchaseManagament.Application.Concrete.Models.RequestModels.Materials
{
    public class UpdateMaterialRM
    {
        public long Id { get; set; }
        public long RequestId { get; set; }
        public long ProductId { get; set; }
        public string Details { get; set; }
        public double Quantity { get; set; }
    }
}
