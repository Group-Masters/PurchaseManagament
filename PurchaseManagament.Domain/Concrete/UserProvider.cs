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
        public string GetUser()
        {
            return _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;
        }
    }
}
