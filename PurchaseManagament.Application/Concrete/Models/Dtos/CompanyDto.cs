﻿using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Application.Concrete.Models.Dtos
{
    public class CompanyDto
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal ManagerThreshold { get; set; }
    }
}
