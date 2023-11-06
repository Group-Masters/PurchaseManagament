using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Domain.Entities
{
    public class logged
    {

        public Int64 Id { get; set; }
        public Int64 EmployeeId { get; set; }
        public Int64 DepartmentId { get; set; }
        public Int64 CompanyId { get; set; }
        public string detail { get; set; }
        public DateTime Date { get; set; } 

    }
}
