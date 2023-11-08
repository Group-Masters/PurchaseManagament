using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Concrete.Models.RequestModels.Employee
{
    public class LoginVM2
    {
        public string UsernameOrEmail { get; set; }
        public string OkCode { get; set; }
    }
}
