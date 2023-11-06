using PurchaseManagament.Domain.Enums;

namespace PurchaseManagament.Application.Concrete.Models.RequestModels.Offers
{
    public class UpdateOfferStateRM
    {
        public long Id { get; set; }
        public virtual Status Status { get; set; }

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
