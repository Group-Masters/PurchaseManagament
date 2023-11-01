using PurchaseManagament.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Concrete.Models.Dtos
{
    public class RequestDTO
    {
        public Int64 Id { get; set; }
        public long ProductId { get; set; }

        public long ApprovingEmployeeId { get; set; }
        public long RequestEmployeeId { get; set; }
        public string Details { get; set; }
        public double Quantity { get; set; }

        public virtual Status State { get; set; } // Durum

        /* Status Durumlar
         * 
            Beklemede = 0,
            Reddedildi = 1,
            Onay = 2,
            YönetimBekleme = 3,
            YönetimOnay = 4,
            YönetimRed = 5,
            
            
            Tamamlandı = 9
         
         */
    }
}
