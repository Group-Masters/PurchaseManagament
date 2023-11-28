using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Concrete.Models.Dtos.ChartDtos
{
    public class MainChartDto
    {
        public long EmployeeCount { get; set; }
        public long RequestCount { get; set; }
        public decimal TotalPrice { get; set; }
        public int CompanyCount { get; set; }
    }
}
