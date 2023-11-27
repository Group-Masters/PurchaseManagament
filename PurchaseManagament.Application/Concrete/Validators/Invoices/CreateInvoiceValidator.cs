﻿using FluentValidation;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Invoices;

namespace PurchaseManagament.Application.Concrete.Validators.Invoices
{
    public class CreateInvoiceValidator : AbstractValidator<CreateInvoiceRM>
    {
        public CreateInvoiceValidator()
        {
            RuleFor(x => x.OfferId).NotEmpty().WithMessage("Teklif numarası boş bırakalamaz").GreaterThan(0).WithMessage("Lütfen 0 dan büyük bir sayı giriniz");
            RuleFor(x => x.ImageSrc)
              .NotNull().WithMessage("Resim dosyası seçilmelidir.")
              .Must(x => FileIsImageFile(x)).WithMessage("Sadece resim dosyası seçilebilir.")
              .Must(x => FileSizeAsKb(x) < 1 * 1024).WithMessage("Dosya boyutu 1 MB dan büyük olamaz.");
        }
        bool FileIsImageFile(string base64FileString)
        {
            // Örnek olarak bir gif resmi için
            //tarayıcıdan upload yapıldığında resim bilgisi [data:image/gif;base64,R0lGODlh7gI2BdU/AP.......] şeklinde gelir.
            //postman ile upload yapıldığında aynı bilgi [R0lGODlh7gI2BdU/AP.......] şeklinde gelir.
            //Aşağıdaki koşul bu nedenle yazıldı.
            var base64FileInfo = base64FileString.Contains("base64") ? base64FileString.Split(",")[1] : base64FileString;
            var fileTypePart = base64FileInfo.Substring(0, 5);
            var fileTypes = new string[] { "iVBOR", "/9J/4", "R0lGO", "/9j/4", "iVBOR" };
            return fileTypes.Contains(fileTypePart);
        }

        //Bu metod base64 string olarak alınan dosyanın boyutunu hesaplar.
        int FileSizeAsKb(string base64FileString)
        {
            //base64 stringden dosyanı kaç KB olduğunu hesaplıyoruz.
            var base64FileInfo = base64FileString.Contains("base64") ? base64FileString.Split(",")[1] : base64FileString;
            var stringLenth = (decimal)base64FileInfo.Length;
            var sizeInBytes = 4M * Math.Ceiling(stringLenth / 3) * 0.5624896334383812M;
            var sizeInKb = sizeInBytes / 1024;
            return (int)sizeInKb;
        }
    }
}
