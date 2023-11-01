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

        public Int64? UserId => GetClaim(ClaimTypes.Sid) != null ? Int64.Parse(GetClaim(ClaimTypes.Sid)) : 1;
       // public Roles? Role => GetClaim(ClaimTypes.Role) != null ? (Roles)Enum.Parse(typeof(Roles), GetClaim(ClaimTypes.Role)) : null;
        public string Username => GetClaim(ClaimTypes.Name) != null ? GetClaim(ClaimTypes.Name) : null;
        public string Email => GetClaim(ClaimTypes.Email) != null ? GetClaim(ClaimTypes.Email) : null;

     //public List<string>? Role => GetClaim(ClaimTypes.Role) != null ? GetClaimList(ClaimTypes.Role) : null;

        public string Ip => _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

        private string GetClaim(string claimType)
        {
            return _httpContextAccessor?.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == claimType)?.Value;
        }
        //private List<string> GetClaimList(string claimType)
        //{
        //  var roles= _httpContextAccessor?.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == claimType)?.Value.Split(',');
        //    return roles.ToList();
        //}

    }
}
