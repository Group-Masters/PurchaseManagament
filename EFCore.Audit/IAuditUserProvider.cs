using System;

namespace EFCore.Audit
{
    public interface IAuditUserProvider
    {
        Int64? UserId { get; }
        // List< string>? Role { get; }
        string Username { get; }
        string Email { get; }
    }
}
