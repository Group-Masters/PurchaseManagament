﻿using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Domain.Abstract
{
    public interface ILoggedService
    {
        Int64? UserId { get; }
        List<Int64>? Role { get; }
        string Username { get; }
        string Email { get; }
        string? Ip {  get; }
    }
}
