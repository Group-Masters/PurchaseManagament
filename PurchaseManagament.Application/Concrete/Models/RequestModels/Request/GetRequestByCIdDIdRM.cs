namespace PurchaseManagament.Application.Concrete.Models.RequestModels.Request
{
    public class GetRequestByCIdDIdRM
    {
        public Int64 CompanyId { get; set; }
        public Int64 DepartmentId { get; set; }
    }
}
