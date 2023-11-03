using PurchaseManagament.Domain.Enums;

namespace PurchaseManagament.Application.Concrete.Models.RequestModels.Request
{
    public class UpdateRequestStateRM
    {
        public Int64 Id { get; set; }
        public virtual Status State { get; set; }

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
