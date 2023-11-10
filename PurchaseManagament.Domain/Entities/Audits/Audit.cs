﻿using Microsoft.EntityFrameworkCore;

namespace PurchaseManagament.Domain.Entities.Audits
{
    public class Audit
    {
        public Guid Id { get; set; }
        public Guid MetaHashPrimaryKey { get; set; }
        public string MetaDisplayName { get; set; }
        public long UserId { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
        public DateTimeOffset DateTimeOffset { get; set; }
        public EntityState EntityState { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual AuditMetaData AuditMetaData { get; set; }
    }
}
