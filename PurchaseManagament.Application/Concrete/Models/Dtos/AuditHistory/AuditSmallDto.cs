﻿namespace PurchaseManagament.Application.Concrete.Models.Dtos.AuditHistory
{
    public class AuditSmallDto
    {
        public Guid Id { get; set; }
        public Guid MetaHashPrimaryKey { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string MetaDisplayName { get; set; }
        public string ReadablePrimaryKey { get; set; }
        public int EntityState { get; set; }
        public DateTime DateTime { get; set; }
    }
}
