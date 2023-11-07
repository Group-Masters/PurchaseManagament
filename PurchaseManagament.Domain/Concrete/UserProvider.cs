using EFCore.Audit;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace PurchaseManagament.Domain.Concrete
{
    public class UserProvider : IAuditUserProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Int64? UserId => GetUser(ClaimTypes.Sid) != null ? Int64.Parse(GetUser(ClaimTypes.Sid)) : null;
        //public Roles? Role => GetUser(ClaimTypes.Role) != null ? (Roles)Enum.Parse(typeof(Roles), GetUser(ClaimTypes.Role)) : null;
        public string Username => GetUser(ClaimTypes.Name) ?? null;
        public string Email => GetUser(ClaimTypes.Email) ?? null;

        public string GetUser(string claimType)
        {
            return _httpContextAccessor?.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == claimType)?.Value;
        }
    }
}
