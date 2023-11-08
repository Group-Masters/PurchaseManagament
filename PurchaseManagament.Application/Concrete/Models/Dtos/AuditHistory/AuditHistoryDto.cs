using Microsoft.EntityFrameworkCore;

namespace PurchaseManagament.Application.Concrete.Models.Dtos.AuditHistory
{
    public class AuditHistoryDto
    {
        public Guid Id { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
        public DateTimeOffset DateTimeOffset { get; set; }
        public EntityState EntityState { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public Guid HashPrimaryKey { get; set; }
        public string ReadablePrimaryKey { get; set; }
        public string Table {  get; set; }
    }
}
