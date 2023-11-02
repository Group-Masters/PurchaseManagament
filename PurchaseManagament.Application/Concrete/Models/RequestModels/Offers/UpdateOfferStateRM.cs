using PurchaseManagament.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Concrete.Models.RequestModels.Offers
{
    public class UpdateOfferStateRM
    {
        public long Id { get; set; }
        public virtual Status Status { get; set; }
        public Int64 ApprovingEmployeeId { get; set; }

        /*
         
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
