using PurchaseManagament.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Concrete.Models.RequestModels.Employee
{
    public class CreateEmployeeVM
    {
        public long CompanyDepartmentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdNumber { get; set; }
        public string BirthYear { get; set; }
        public Gender Gender { get; set; }
        public string Username { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
