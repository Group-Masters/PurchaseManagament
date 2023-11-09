using PurchaseManagament.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Utils.LogServices.LoginLogServices
{
    public class TxtLogla : ILoginLogService
    {
        public async Task Logla(Employee employee)
        {
            DateTime dateTime = DateTime.Now;

            // Log txt tutuyoruz
            var LogUser = employee.Name.ToUpper() + " " + employee.Surname.ToUpper();

            var LoginLog = dateTime.ToString() + " " + LogUser;

            var LogMessage = LoginLog + " " + "Giriş Yaptı\n";

            byte[] writeArr = Encoding.UTF8.GetBytes(LogMessage);

            using (FileStream fileStream = new FileStream(@$"C:\Users\sefa\Source\Repos\PurchaseManagament\LogSaves\LoginLogSaves\{employee.Name + employee.Surname}.txt", FileMode.Append,
                                              FileAccess.Write,
                                              FileShare.None))
            {
                await fileStream.WriteAsync(writeArr, 0, writeArr.Length);
            }
        }
    }
}
