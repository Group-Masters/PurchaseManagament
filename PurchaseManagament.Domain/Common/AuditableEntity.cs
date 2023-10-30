namespace PurchaseManagament.Domain.Common
{
    public abstract class AuditableEntity:BaseEntity
    {
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
      
        public string CreatedIP { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedIP { get; set; }     
    }
}
