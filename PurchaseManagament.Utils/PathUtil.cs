using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace PurchaseManagament.Utils
{
    public static class PathUtil
    {
        
        public static string GenerateFileNameFromBase64File(string base64Image)
        {
            var date = DateTime.Now;
            var extension = GetExtensionFromBase64String(base64Image);
            var fileName = $"{date.Day}_{date.Month}_{date.Year}_{date.Hour}_{date.Minute}_{date.Second}_{date.Millisecond}{extension}";
            return fileName;
        }


        //public static string CreatePath(string imageString, WebHostEnvironment hostingEnvironment, string path)
        //{                                                   
           

        //    var fileName = PathUtil.GenerateFileNameFromBase64File(imageString);
        //    var filePath = Path.Combine(hostingEnvironment.WebRootPath, path, fileName);

        //    // Base64 string olarak gelen dosya byte dizisine çevriliyor.
        //    var imageDataAsByteArray = Convert.FromBase64String(imageString);

        //    // Byte dizisi MemoryStream'e yazmak üzere MemoryStream'e aktarılıyor.
        //    using (var ms = new MemoryStream(imageDataAsByteArray))
        //    {
        //        ms.Position = 0;

        //        // MemoryStream'den dosyayı kaydediyoruz.
        //        using (var fs = new FileStream(filePath, FileMode.Create))
        //        {
        //            ms.CopyTo(fs);
        //        }
        //    }

        //    // Dosyanın yolu [Projenin kök dizininin yolu] + ["images"] + ["product-images"] + ["dosyanın adı.uzantısı"]
        //    var relativePath = Path.Combine(path, fileName);
        //    return relativePath;
        
        //}




        //Dosya base64 string olarak alınmaktadır.
        //base64 string bilgi içerisinde yer alan ilk 5 karakterden dosya türü öğrenilebilmektedir.
        private static string GetExtensionFromBase64String(string base64Image)
        {
            //Örnek olarak bir gif resmi için 
            //tarayıcıdan upload yapıldığında resim bilgisi [data:image/gif;base64,R0lGODlh7gI2BdU/AP.......] şeklinde gelir.
            //postman ile upload yapıldığında aynı bilgi [R0lGODlh7gI2BdU/AP.......] şeklinde gelir.
            //Aşağıdaki koşul bu nedenle yazıldı.
            var fileTypeString = base64Image.Contains("base64") ? base64Image.Split(",")[1] : base64Image;
            switch (fileTypeString.Substring(0, 5).ToUpper())
            {
                case "iVBOR":
                    return ".png";
                case "/9J/4":
                    return ".jpg";
                case "R0lGO":
                    return ".gif";
                default:
                    return ".png";
            }
        }
    }
}
