namespace PurchaseManagament.Application.Concrete.Models.Dtos
{
    public class StockOperationsDto
    {
        public Int64 Id { get; set; }
        public long ReceivingEmployeeId { get; set; }
        public long CompanyStockId { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverSurname { get; set; }
        public string ProductName { get; set; }
        public double Quantity { get; set; }
        //public bool OperationType { get; set; }
    }
}
