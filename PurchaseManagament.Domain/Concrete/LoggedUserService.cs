using Microsoft.AspNetCore.Http;
using PurchaseManagament.Domain.Abstract;
using PurchaseManagament.Domain.Entities;
using System.Data;
using System.Security.Claims;

namespace PurchaseManagament.Domain.Concrete
{
    public class LoggedUserService : ILoggedService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LoggedUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Int64? UserId => GetClaim(ClaimTypes.Sid) != null ? Int64.Parse(GetClaim(ClaimTypes.Sid)) : null;
        //public List<Int64>? Role => GetClaim(ClaimTypes.Role) != null ? GetRoles(GetClaim(ClaimTypes.Role)) : null;
        public List<Int64>? Role => GetClaim(ClaimTypes.Role) != null ? GetClaims(ClaimTypes.Role).Select(x=>Convert.ToInt64(x)).ToList(): null;
        public string Username => GetClaim(ClaimTypes.Name) != null ? GetClaim(ClaimTypes.Name) : null;
        public string Email => GetClaim(ClaimTypes.Email) != null ? GetClaim(ClaimTypes.Email) : null;

     //public List<string>? Role => GetClaim(ClaimTypes.Role) != null ? GetClaimList(ClaimTypes.Role) : null;

        public string Ip => _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

        private string GetClaim(string claimType)
        {
            return _httpContextAccessor?.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == claimType)?.Value;
        }
         private List<string> GetClaims(string claimType)
        {
            return _httpContextAccessor?.HttpContext?.User.Claims.Where(x => x.Type == claimType).Select(x => x.Value).ToList();
        }
        public List<Int64> GetRoles(List<Int64> roles)
        {
            // Role listesini uygun bir şekilde işleyin
            // Örneğin, object tipini Int64'e dönüştürerek işleyebilirsiniz
            List<Int64> roleList = roles.Select(x => Convert.ToInt64(x)).ToList();

            // Diğer işlemleri gerçekleştirin

            return roleList;
        }

    

    }
}
