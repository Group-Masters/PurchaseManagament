namespace PurchaseManagament.Domain.Entities.Audits
{
    public class AuditMetaData
    {
        public Guid HashPrimaryKey { get; set; }
        public string ReadablePrimaryKey { get; set; }
        public string Table { get; set; }
        public string DisplayName { get; set; }

        public virtual IEnumerable<Audit> Audits { get; set; }
    }
}
