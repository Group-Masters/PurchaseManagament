﻿namespace PurchaseManagament.Persistence.Concrete.Audits
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class AuditableAttribute : Attribute
    { }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class NotAuditableAttribute : Attribute
    { }
}
