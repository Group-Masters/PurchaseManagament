using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Domain.Abstract
{
    public interface ILoggedService
    {
        Int64? UserId { get; }
      // List< string>? Role { get; }
        string Username { get; }
        string Email { get; }
        string? Ip {  get; }
    }
}
