﻿namespace PurchaseManagament.Domain.Entities
{
    public class Employee : AuditableEntity
    {
        public long CompanyDepartmentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }

        public virtual CompanyDepartment CompanyDepartment { get; set; }
        public virtual EmployeeDetail EmployeeDetail { get; set; }
        public virtual IEnumerable<CompanyDepartment> CompanyDepartment { get; set; }
        public virtual EmployeeDetail? EmployeeDetail { get; set; }
        public virtual IEnumerable<EmployeeRole> EmployeeRoles { get; set; }
        public virtual IEnumerable<Offer> Offers { get; set; }
        public virtual IEnumerable<Request> Requests { get; set; }
        public virtual IEnumerable<StockOperations> StockOperations { get; set; }
              
    }
    public  enum Gender
    {
        Male=1,
        Female,
    }
}
