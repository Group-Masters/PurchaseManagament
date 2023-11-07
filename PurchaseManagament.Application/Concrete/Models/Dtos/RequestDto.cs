﻿using PurchaseManagament.Domain.Enums;

namespace PurchaseManagament.Application.Concrete.Models.Dtos
{
    public class RequestDto
    {
        public Int64 Id { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string MeasuringUnitName{ get; set; }
        public long ApprovingEmployeeId { get; set; }
        public string ApprovingEmployeeName { get; set; }
        public string ApprovingEmployeeSurname { get; set; }
        public long RequestEmployeeId { get; set; }
        public string RequestEmployeeName { get; set; }
        public string RequestEmployeeSurname { get; set; }
        public string Details { get; set; }
        public double Quantity { get; set; }
        public DateTime? CreatedDate { get; set; }

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
