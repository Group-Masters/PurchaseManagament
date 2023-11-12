namespace PurchaseManagament.Application.Concrete.Models.RequestModels.Request
{
    public class CreateRequestRM
    {
        public long ProductId { get; set; }
        //public long ApprovingEmployeeId { get; set; }
        //public long RequestEmployeeId { get; set; }
        public string? Details { get; set; }
        public double Quantity { get; set; }
    }
}
