﻿using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Application.Concrete.Models.Dtos
{
    public class CompanyDto
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public virtual IEnumerable<CompanyDepartment> CompanyDepartments { get; set; } // Şirket ve Departman
        public virtual IEnumerable<CompanyStock> CompanyStocks { get; set; } // Şirket Stok
    }
}
