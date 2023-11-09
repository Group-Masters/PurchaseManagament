using PurchaseManagament.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Utils.LogServices.LoginLogServices
{
    public interface ILoginLogService
    {
        Task Logla(Employee employee);
    }
}
