using IdNumberCheck;

namespace PurchaseManagament.Utils
{
    public static class IdentityUtils
    {
        public static async Task<bool> TCControl(long TC, string Name, string Surname, int birthyear)
        {
            var sonuç = false;
            using (KPSPublicSoapClient kk = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap))
            {

                var sonuç2 = await kk.TCKimlikNoDogrulaAsync(TC, Name, Surname, birthyear);
                sonuç = sonuç2.Body.TCKimlikNoDogrulaResult;
            };
            return sonuç;
        }
    }
}
