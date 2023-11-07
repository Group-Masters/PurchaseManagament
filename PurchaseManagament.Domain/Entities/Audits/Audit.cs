﻿using Microsoft.EntityFrameworkCore;

namespace PurchaseManagament.Domain.Entities.Audits
{
    public class Audit
    {
        public Guid Id { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
        public DateTimeOffset DateTimeOffset { get; set; }
        public EntityState EntityState { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }

        public virtual AuditMetaData AuditMetaData { get; set; }
    }
}