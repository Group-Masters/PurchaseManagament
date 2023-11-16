using Microsoft.IdentityModel.Tokens;
using Microsoft.WindowsAPICodePack.Shell;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Report;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace PurchaseManagament.Application.Concrete.Services.PDFServices
{
    public class ReportToPdfService
    {
        private readonly IReportService _reportService;

        public ReportToPdfService(IReportService reportService)
        {
            _reportService = reportService;
        }

        

        
        public async Task GenerateReportToPDFByEmploye(GetByIdVM getByIdVM)
        {
            var employeReports = await _reportService.GetReportByEmployeeId(getByIdVM);

            var yol = KnownFolders.Downloads.Path; // Dowloads dosya yolu

            QuestPDF.Settings.License = LicenseType.Community;
           var reportDtos = employeReports.Data;
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A3.Landscape());
                    page.Margin(1, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(16).FontFamily("Times New Roman"));

                    page.Header()
                    .Layers(layers =>
                    {
                        layers.Layer()
                        .Height(3, Unit.Centimetre)
                        .PaddingTop(1, Unit.Centimetre)
                        .AlignCenter()
                        .Text($"{employeReports.Data.Select(q => q.Requestby).First().ToString()} - {employeReports.Data.Select(q => q.Companydepartment).First().ToString()} Talep Dökümü")
                        .SemiBold().FontSize(22).FontColor(Colors.Black);


                        layers
                            .Layer()
                            .PaddingTop(1, Unit.Centimetre)
                            .AlignRight()
                            .Width(100)
                            .Text(DateTime.Now.ToString())
                            .SemiBold().FontSize(16).FontColor(Colors.Black);

                        layers
                            .PrimaryLayer()
                            .AlignTop()
                            .Width(100)
                            .Image("C:\\Users\\sefa\\Source\\Repos\\PurchaseManagament\\PurchaseManagament.Application\\Concrete\\Services\\PDFServices\\logo.jpeg");

                    });

                    //.Height(2, Unit.Centimetre)
                    //.AlignCenter()
                    //.Text($"{employeReports.Data.Select(q => q.Requestby).First().ToString()} - {employeReports.Data.Select(q => q.Companydepartment).First().ToString()} Talep Dökümü")
                    //.SemiBold().FontSize(22).FontColor(Colors.Black);

                    page.Content()
                    .Layers(layers =>
                    {
                        layers.PrimaryLayer()
                        .AlignCenter()
                        .Table(table =>
                         {
                             IContainer DefaultCellStyle(IContainer container, string backgroundColor)
                             {
                                 return container
                                     .Border(1)
                                     .BorderColor(Colors.Grey.Lighten1)
                                     .Background(backgroundColor)
                                     .PaddingVertical(5)
                                     .PaddingHorizontal(10)
                                     .AlignCenter()
                                     .AlignMiddle();
                             }

                             table.ColumnsDefinition(columns =>
                             {

                                 columns.ConstantColumn(113);
                                 columns.ConstantColumn(113);
                                 columns.ConstantColumn(113);
                                 columns.ConstantColumn(113);
                                 columns.ConstantColumn(113);
                                 columns.ConstantColumn(113);
                                 columns.ConstantColumn(113);
                                 columns.ConstantColumn(113);
                                 columns.ConstantColumn(113);
                                 columns.ConstantColumn(113);
                             });

                             table.Header(header =>
                             {
                                 // please be sure to call the 'header' handler!


                                 header.Cell().Element(CellStyle).AlignCenter().Text("Talep Numarası").ExtraBold();
                                 header.Cell().Element(CellStyle).AlignCenter().Text("Durumu").ExtraBold();
                                 header.Cell().Element(CellStyle).AlignCenter().Text("Ürün Adı").ExtraBold();
                                 header.Cell().Element(CellStyle).AlignCenter().Text("Adet Birim").ExtraBold();
                                 header.Cell().Element(CellStyle).AlignCenter().Text("Talep Tarihi").ExtraBold();
                                 header.Cell().Element(CellStyle).AlignCenter().Text("Onaylayan").ExtraBold();
                                 header.Cell().Element(CellStyle).AlignCenter().Text("Fiyat Birim").ExtraBold();
                                 header.Cell().Element(CellStyle).AlignCenter().Text("Tedarikçi Adı").ExtraBold();
                                 header.Cell().Element(CellStyle).AlignCenter().Text("Tedarik Tarihi").ExtraBold();
                                 header.Cell().Element(CellStyle).AlignCenter().Text("Fatura Numarası").ExtraBold();

                                 // you can extend existing styles by creating additional methods
                                 IContainer CellStyle(IContainer container) => DefaultCellStyle(container, Colors.Grey.Lighten3);


                             });

                             var deneme = reportDtos.ToList();
                             int sayac = 0;
                             for (uint i = 0; i < reportDtos.Count; i++)
                             {

                                 table.Cell().Row(i + 1).Column(1).Element(CellStyle).Text(deneme[sayac].RequestId.ToString() ?? "-");
                                 table.Cell().Row(i + 1).Column(2).Element(CellStyle).Text(deneme[sayac].Status.ToString() ?? "-");
                                 table.Cell().Row(i + 1).Column(3).Element(CellStyle).Text(deneme[sayac].product ?? "-");
                                 table.Cell().Row(i + 1).Column(4).Element(CellStyle).Text(deneme[sayac].Quantity ?? "-");
                                 table.Cell().Row(i + 1).Column(5).Element(CellStyle).Text(deneme[sayac].CreateDate ?? "-");
                                 table.Cell().Row(i + 1).Column(6).Element(CellStyle).Text(deneme[sayac].ApprovedEmployee ?? "-");
                                 table.Cell().Row(i + 1).Column(7).Element(CellStyle).Text(deneme[sayac].Prices ?? "-");
                                 table.Cell().Row(i + 1).Column(8).Element(CellStyle).Text(deneme[sayac].supplier ?? "-");
                                 table.Cell().Row(i + 1).Column(9).Element(CellStyle).Text(deneme[sayac].supplyDate ?? "-");
                                 table.Cell().Row(i + 1).Column(10).Element(CellStyle).Text(deneme[sayac].InvoiceId.ToString() ?? "-");

                                 sayac++;
                             }

                             IContainer CellStyle(IContainer container) => DefaultCellStyle(container, Colors.Grey.Lighten3);
                         });

                    });

                });
            })
        .GeneratePdf($"{yol + "\\"}{DateTime.Now.ToString().Replace(" ", "").Replace(".", "I").Replace(":", "I")}.pdf");


        }

        public async Task GenerateReportToPDFByCompany(GetByIdVM getByIdVM)
        {
            var employeReports = await _reportService.GetReportByCompanyId(getByIdVM);

            var yol = KnownFolders.Downloads.Path; // Dowloads dosya yolu

            QuestPDF.Settings.License = LicenseType.Community;
            var reportDtos = employeReports.Data;
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A2.Landscape());
                    page.Margin(1, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(16).FontFamily("Times New Roman"));

                    page.Header() // Baslik kısmı
                    .Layers(layers =>
                    {
                        layers.Layer()
                        .Height(3, Unit.Centimetre)
                        .PaddingTop(1, Unit.Centimetre)
                        .AlignCenter()
                        .Text($"{employeReports.Data.Select(q => q.Companydepartment).First().ToString()} Talep Dökümü")
                        .SemiBold().FontSize(22).FontColor(Colors.Black);


                        layers
                            .Layer()
                            .PaddingTop(1, Unit.Centimetre)
                            .AlignRight()
                            .Width(100)
                            .Text(DateTime.Now.ToString())
                            .SemiBold().FontSize(16).FontColor(Colors.Black);

                        layers
                            .PrimaryLayer()
                            .AlignTop()
                            .Width(100)
                            .Image("C:\\Users\\sefa\\Source\\Repos\\PurchaseManagament\\PurchaseManagament.Application\\Concrete\\Services\\PDFServices\\logo.jpeg");

                    });

                    page.Content()
                    .Layers(layers =>
                    {
                        layers.PrimaryLayer()
                        .AlignCenter()
                        .Table(table =>
                        {
                            IContainer DefaultCellStyle(IContainer container, string backgroundColor)
                            {
                                return container
                                    .Border(1)
                                    .BorderColor(Colors.Grey.Lighten1)
                                    .Background(backgroundColor)
                                    .PaddingVertical(5)
                                    .PaddingHorizontal(10)
                                    .AlignCenter()
                                    .AlignMiddle();
                            }

                            table.ColumnsDefinition(columns =>
                            {

                                columns.ConstantColumn(135);
                                columns.ConstantColumn(135);
                                columns.ConstantColumn(135);
                                columns.ConstantColumn(135);
                                columns.ConstantColumn(135);
                                columns.ConstantColumn(135);
                                columns.ConstantColumn(135);
                                columns.ConstantColumn(135);
                                columns.ConstantColumn(135);
                                columns.ConstantColumn(135);
                                columns.ConstantColumn(135);
                                columns.ConstantColumn(135);
                            });

                            table.Header(header =>
                            {
                                // please be sure to call the 'header' handler!


                                header.Cell().Element(CellStyle).AlignCenter().Text("Talep Numarası").ExtraBold();
                                header.Cell().Element(CellStyle).AlignCenter().Text("Durumu").ExtraBold();
                                header.Cell().Element(CellStyle).AlignCenter().Text("Talep Eden").ExtraBold();
                                header.Cell().Element(CellStyle).AlignCenter().Text("Şirket\nDepartman").ExtraBold();
                                header.Cell().Element(CellStyle).AlignCenter().Text("Ürün Adı").ExtraBold();
                                header.Cell().Element(CellStyle).AlignCenter().Text("Adet Birim").ExtraBold();
                                header.Cell().Element(CellStyle).AlignCenter().Text("Talep Tarihi").ExtraBold();
                                header.Cell().Element(CellStyle).AlignCenter().Text("Onaylayan").ExtraBold();
                                header.Cell().Element(CellStyle).AlignCenter().Text("Fiyat Birim").ExtraBold();
                                header.Cell().Element(CellStyle).AlignCenter().Text("Tedarikçi Adı").ExtraBold();
                                header.Cell().Element(CellStyle).AlignCenter().Text("Tedarik Tarihi").ExtraBold();
                                header.Cell().Element(CellStyle).AlignCenter().Text("Fatura Numarası").ExtraBold();

                                // you can extend existing styles by creating additional methods
                                IContainer CellStyle(IContainer container) => DefaultCellStyle(container, Colors.Grey.Lighten3);


                            });

                            var deneme = reportDtos.ToList();
                            int sayac = 0;
                            for (uint i = 0; i < reportDtos.Count; i++)
                            {

                                table.Cell().Row(i + 1).Column(1).Element(CellStyle).Text(deneme[sayac].RequestId.ToString() ?? "-");
                                table.Cell().Row(i + 1).Column(2).Element(CellStyle).Text(deneme[sayac].Status.ToString() ?? "-");
                                table.Cell().Row(i + 1).Column(3).Element(CellStyle).Text(deneme[sayac].Requestby ?? "-");
                                table.Cell().Row(i + 1).Column(4).Element(CellStyle).Text(deneme[sayac].Companydepartment ?? "-");
                                table.Cell().Row(i + 1).Column(5).Element(CellStyle).Text(deneme[sayac].product ?? "-");
                                table.Cell().Row(i + 1).Column(6).Element(CellStyle).Text(deneme[sayac].Quantity ?? "-");
                                table.Cell().Row(i + 1).Column(7).Element(CellStyle).Text(deneme[sayac].CreateDate ?? "-");
                                table.Cell().Row(i + 1).Column(8).Element(CellStyle).Text(deneme[sayac].ApprovedEmployee ?? "-");
                                table.Cell().Row(i + 1).Column(9).Element(CellStyle).Text(deneme[sayac].Prices ?? "-");
                                table.Cell().Row(i + 1).Column(10).Element(CellStyle).Text(deneme[sayac].supplier ?? "-");
                                table.Cell().Row(i + 1).Column(11).Element(CellStyle).Text(deneme[sayac].supplyDate ?? "-");
                                table.Cell().Row(i + 1).Column(12).Element(CellStyle).Text(deneme[sayac].InvoiceId.ToString() ?? "-");

                                sayac++;
                            }

                            IContainer CellStyle(IContainer container) => DefaultCellStyle(container, Colors.Grey.Lighten3);
                        });
                    });
                });
            })
        .GeneratePdf($"{yol + "\\"}{DateTime.Now.ToString().Replace(" ", "").Replace(".", "I").Replace(":", "I")}.pdf");


        }

        public async Task GenerateReportToPDFByDepartman(GetReportDepartmentVM getByIdVM)
        {
            var employeReports = await _reportService.GetReportByDepartmentId(getByIdVM);

            var yol = KnownFolders.Downloads.Path; // Dowloads dosya yolu

            QuestPDF.Settings.License = LicenseType.Community;
            var reportDtos = employeReports.Data;
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A2.Landscape());
                    page.Margin(1, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(16).FontFamily("Times New Roman"));

                    page.Header() // Baslik kısmı
                        .Layers(layers =>
                        {
                            layers.Layer()
                            .Height(3, Unit.Centimetre)
                            .PaddingTop(1, Unit.Centimetre)
                            .AlignCenter()
                            .Text($"{employeReports.Data.Select(q => q.Companydepartment).First().ToString()} Talep Dökümü")
                            .SemiBold().FontSize(22).FontColor(Colors.Black);


                            layers
                                .Layer()
                                .PaddingTop(1, Unit.Centimetre)
                                .AlignRight()
                                .Width(100)
                                .Text(DateTime.Now.ToString())
                                .SemiBold().FontSize(16).FontColor(Colors.Black);

                            layers
                                .PrimaryLayer()
                                .AlignTop()
                                .Width(100)
                                .Image("C:\\Users\\sefa\\Source\\Repos\\PurchaseManagament\\PurchaseManagament.Application\\Concrete\\Services\\PDFServices\\logo.jpeg");

                        });

                    page.Content()
                    .Layers(layers =>
                    {
                        layers.PrimaryLayer()
                        .AlignCenter()
                        .Table(table =>
                        {
                            IContainer DefaultCellStyle(IContainer container, string backgroundColor)
                            {
                                return container
                                    .Border(1)
                                    .BorderColor(Colors.Grey.Lighten1)
                                    .Background(backgroundColor)
                                    .PaddingVertical(5)
                                    .PaddingHorizontal(10)
                                    .AlignCenter()
                                    .AlignMiddle();
                            }

                            table.ColumnsDefinition(columns =>
                            {

                                columns.ConstantColumn(135);
                                columns.ConstantColumn(135);
                                columns.ConstantColumn(135);
                                columns.ConstantColumn(135);
                                columns.ConstantColumn(135);
                                columns.ConstantColumn(135);
                                columns.ConstantColumn(135);
                                columns.ConstantColumn(135);
                                columns.ConstantColumn(135);
                                columns.ConstantColumn(135);
                                columns.ConstantColumn(135);
                                columns.ConstantColumn(135);
                            });

                            table.Header(header =>
                            {
                                // please be sure to call the 'header' handler!


                                header.Cell().Element(CellStyle).AlignCenter().Text("Talep Numarası").ExtraBold();
                                header.Cell().Element(CellStyle).AlignCenter().Text("Durumu").ExtraBold();
                                header.Cell().Element(CellStyle).AlignCenter().Text("Talep Eden").ExtraBold();
                                header.Cell().Element(CellStyle).AlignCenter().Text("Şirket\nDepartman").ExtraBold();
                                header.Cell().Element(CellStyle).AlignCenter().Text("Ürün Adı").ExtraBold();
                                header.Cell().Element(CellStyle).AlignCenter().Text("Adet Birim").ExtraBold();
                                header.Cell().Element(CellStyle).AlignCenter().Text("Talep Tarihi").ExtraBold();
                                header.Cell().Element(CellStyle).AlignCenter().Text("Onaylayan").ExtraBold();
                                header.Cell().Element(CellStyle).AlignCenter().Text("Fiyat Birim").ExtraBold();
                                header.Cell().Element(CellStyle).AlignCenter().Text("Tedarikçi Adı").ExtraBold();
                                header.Cell().Element(CellStyle).AlignCenter().Text("Tedarik Tarihi").ExtraBold();
                                header.Cell().Element(CellStyle).AlignCenter().Text("Fatura Numarası").ExtraBold();

                                // you can extend existing styles by creating additional methods
                                IContainer CellStyle(IContainer container) => DefaultCellStyle(container, Colors.Grey.Lighten3);


                            });

                            var deneme = reportDtos.ToList();
                            int sayac = 0;
                            for (uint i = 0; i < reportDtos.Count; i++)
                            {

                                table.Cell().Row(i + 1).Column(1).Element(CellStyle).Text(deneme[sayac].RequestId.ToString() ?? "-");
                                table.Cell().Row(i + 1).Column(2).Element(CellStyle).Text(deneme[sayac].Status.ToString() ?? "-");
                                table.Cell().Row(i + 1).Column(3).Element(CellStyle).Text(deneme[sayac].Requestby ?? "-");
                                table.Cell().Row(i + 1).Column(4).Element(CellStyle).Text(deneme[sayac].Companydepartment ?? "-");
                                table.Cell().Row(i + 1).Column(5).Element(CellStyle).Text(deneme[sayac].product ?? "-");
                                table.Cell().Row(i + 1).Column(6).Element(CellStyle).Text(deneme[sayac].Quantity ?? "-");
                                table.Cell().Row(i + 1).Column(7).Element(CellStyle).Text(deneme[sayac].CreateDate ?? "-");
                                table.Cell().Row(i + 1).Column(8).Element(CellStyle).Text(deneme[sayac].ApprovedEmployee ?? "-");
                                table.Cell().Row(i + 1).Column(9).Element(CellStyle).Text(deneme[sayac].Prices ?? "-");
                                table.Cell().Row(i + 1).Column(10).Element(CellStyle).Text(deneme[sayac].supplier ?? "-");
                                table.Cell().Row(i + 1).Column(11).Element(CellStyle).Text(deneme[sayac].supplyDate ?? "-");
                                table.Cell().Row(i + 1).Column(12).Element(CellStyle).Text(deneme[sayac].InvoiceId.ToString() ?? "-");

                                sayac++;
                            }

                            IContainer CellStyle(IContainer container) => DefaultCellStyle(container, Colors.Grey.Lighten3);
                        });
                    });
                    

                });
            })
        .GeneratePdf($"{yol + "\\"}{DateTime.Now.ToString().Replace(" ", "").Replace(".", "I").Replace(":", "I")}.pdf");


        }


        public async Task GenerateReportToPDFByProduct(GetReportProductVM getByIdVM)
        {
            var employeReports = await _reportService.GetProductReport(getByIdVM);

            var yol = KnownFolders.Downloads.Path; // Dowloads dosya yolu

            QuestPDF.Settings.License = LicenseType.Community;
            var reportDtos = employeReports.Data;
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A2.Landscape());
                    page.Margin(1, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(16).FontFamily("Times New Roman"));

                    page.Header() // Baslik kısmı
                        .Layers(layers =>
                        {
                            layers.Layer()
                            .Height(3, Unit.Centimetre)
                            .PaddingTop(1, Unit.Centimetre)
                            .AlignCenter()
                            .Text($"{employeReports.Data.Select(q => q.product).First().ToString()} - {employeReports.Data.Select(q => q.Companydepartment).First().ToString()} Talep Dökümü")
                            .SemiBold().FontSize(22).FontColor(Colors.Black);


                            layers
                                .Layer()
                                .PaddingTop(1, Unit.Centimetre)
                                .AlignRight()
                                .Width(100)
                                .Text(DateTime.Now.ToString())
                                .SemiBold().FontSize(16).FontColor(Colors.Black);

                            layers
                                .PrimaryLayer()
                                .AlignTop()
                                .Width(100)
                                .Image("C:\\Users\\sefa\\Source\\Repos\\PurchaseManagament\\PurchaseManagament.Application\\Concrete\\Services\\PDFServices\\logo.jpeg");

                        });

                    page.Content()
                    .Layers(layers =>
                    {
                        layers.PrimaryLayer()
                       .AlignCenter()
                       .Table(table =>
                       {
                           IContainer DefaultCellStyle(IContainer container, string backgroundColor)
                           {
                               return container
                                   .Border(1)
                                   .BorderColor(Colors.Grey.Lighten1)
                                   .Background(backgroundColor)
                                   .PaddingVertical(5)
                                   .PaddingHorizontal(10)
                                   .AlignCenter()
                                   .AlignMiddle();
                           }

                           table.ColumnsDefinition(columns =>
                           {

                               columns.ConstantColumn(135);
                               columns.ConstantColumn(135);
                               columns.ConstantColumn(135);
                               columns.ConstantColumn(135);
                               columns.ConstantColumn(135);
                               columns.ConstantColumn(135);
                               columns.ConstantColumn(135);
                               columns.ConstantColumn(135);
                               columns.ConstantColumn(135);
                               columns.ConstantColumn(135);
                               columns.ConstantColumn(135);
                               columns.ConstantColumn(135);
                           });

                           table.Header(header =>
                           {
                               // please be sure to call the 'header' handler!


                               header.Cell().Element(CellStyle).AlignCenter().Text("Talep Numarası").ExtraBold();
                               header.Cell().Element(CellStyle).AlignCenter().Text("Durumu").ExtraBold();
                               header.Cell().Element(CellStyle).AlignCenter().Text("Talep Eden").ExtraBold();
                               header.Cell().Element(CellStyle).AlignCenter().Text("Şirket\nDepartman").ExtraBold();
                               header.Cell().Element(CellStyle).AlignCenter().Text("Ürün Adı").ExtraBold();
                               header.Cell().Element(CellStyle).AlignCenter().Text("Adet Birim").ExtraBold();
                               header.Cell().Element(CellStyle).AlignCenter().Text("Talep Tarihi").ExtraBold();
                               header.Cell().Element(CellStyle).AlignCenter().Text("Onaylayan").ExtraBold();
                               header.Cell().Element(CellStyle).AlignCenter().Text("Fiyat Birim").ExtraBold();
                               header.Cell().Element(CellStyle).AlignCenter().Text("Tedarikçi Adı").ExtraBold();
                               header.Cell().Element(CellStyle).AlignCenter().Text("Tedarik Tarihi").ExtraBold();
                               header.Cell().Element(CellStyle).AlignCenter().Text("Fatura Numarası").ExtraBold();
                               // you can extend existing styles by creating additional methods
                               IContainer CellStyle(IContainer container) => DefaultCellStyle(container, Colors.Grey.Lighten3);


                           });

                           var deneme = reportDtos.ToList();
                           int sayac = 0;
                           for (uint i = 0; i < reportDtos.Count; i++)
                           {
                               table.Cell().Row(i + 1).Column(1).Element(CellStyle).Text(deneme[sayac].RequestId.ToString() ?? "-");
                               table.Cell().Row(i + 1).Column(2).Element(CellStyle).Text(deneme[sayac].Status.ToString() ?? "-");
                               table.Cell().Row(i + 1).Column(3).Element(CellStyle).Text(deneme[sayac].Requestby ?? "-");
                               table.Cell().Row(i + 1).Column(4).Element(CellStyle).Text(deneme[sayac].Companydepartment ?? "-");
                               table.Cell().Row(i + 1).Column(5).Element(CellStyle).Text(deneme[sayac].product ?? "-");
                               table.Cell().Row(i + 1).Column(6).Element(CellStyle).Text(deneme[sayac].Quantity ?? "-");
                               table.Cell().Row(i + 1).Column(7).Element(CellStyle).Text(deneme[sayac].CreateDate ?? "-");
                               table.Cell().Row(i + 1).Column(8).Element(CellStyle).Text(deneme[sayac].ApprovedEmployee ?? "-");
                               table.Cell().Row(i + 1).Column(9).Element(CellStyle).Text(deneme[sayac].Prices ?? "-");
                               table.Cell().Row(i + 1).Column(10).Element(CellStyle).Text(deneme[sayac].supplier ?? "-");
                               table.Cell().Row(i + 1).Column(11).Element(CellStyle).Text(deneme[sayac].supplyDate ?? "-");
                               table.Cell().Row(i + 1).Column(12).Element(CellStyle).Text(deneme[sayac].InvoiceId.ToString() ?? "-");

                               sayac++;
                           }

                           IContainer CellStyle(IContainer container) => DefaultCellStyle(container, Colors.Grey.Lighten3);
                       });
                    });

                });
            })
        .GeneratePdf($"{yol + "\\"}{DateTime.Now.ToString().Replace(" ", "").Replace(".", "I").Replace(":", "I")}.pdf");


        }






        public async Task GenerateReportToPDFBySupplier(GetReportSupplierVM getByIdVM)
        {
            var employeReports = await _reportService.GetSupplierReport(getByIdVM);

            var yol = KnownFolders.Downloads.Path; // Dowloads dosya yolu

            QuestPDF.Settings.License = LicenseType.Community;
            var reportDtos = employeReports.Data;
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A3.Landscape());
                    page.Margin(1, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(16).FontFamily("Times New Roman"));

                    page.Header() // Baslik kısmı
                        .Layers(layers =>
                        {
                            layers.Layer()
                            .Height(3, Unit.Centimetre)
                            .PaddingTop(1, Unit.Centimetre)
                            .AlignCenter()
                            .Text($"{employeReports.Data.Select(q => q.SupplierName).First().ToString()} - Tedarik Dökümü")
                            .SemiBold().FontSize(22).FontColor(Colors.Black);


                            layers
                                .Layer()
                                .PaddingTop(1, Unit.Centimetre)
                                .AlignRight()
                                .Width(100)
                                .Text(DateTime.Now.ToString())
                                .SemiBold().FontSize(16).FontColor(Colors.Black);

                            layers
                                .PrimaryLayer()
                                .AlignTop()
                                .Width(100)
                                .Image("C:\\Users\\sefa\\Source\\Repos\\PurchaseManagament\\PurchaseManagament.Application\\Concrete\\Services\\PDFServices\\logo.jpeg");

                        });

                    page.Content()
                    .Layers(layers =>
                    {
                        layers.PrimaryLayer()
                       .AlignCenter()
                       .Table(table =>
                       {
                           IContainer DefaultCellStyle(IContainer container, string backgroundColor)
                           {
                               return container
                                   .Border(1)
                                   .BorderColor(Colors.Grey.Lighten1)
                                   .Background(backgroundColor)
                                   .PaddingVertical(5)
                                   .PaddingHorizontal(10)
                                   .AlignCenter()
                                   .AlignMiddle();
                           }

                           table.ColumnsDefinition(columns =>
                           {

                               columns.ConstantColumn(140);
                               columns.ConstantColumn(140);
                               columns.ConstantColumn(140);
                               columns.ConstantColumn(140);
                               columns.ConstantColumn(140);
                               columns.ConstantColumn(140);
                               columns.ConstantColumn(140);
                               columns.ConstantColumn(140);
                           });

                           table.Header(header =>
                           {
                               // please be sure to call the 'header' handler!


                               header.Cell().Element(CellStyle).AlignCenter().Text("Tedarikci").ExtraBold();
                               header.Cell().Element(CellStyle).AlignCenter().Text("Teklif ID").ExtraBold();
                               header.Cell().Element(CellStyle).AlignCenter().Text("Teklif\nOluşturulma Tarih").ExtraBold();
                               header.Cell().Element(CellStyle).AlignCenter().Text("Durum").ExtraBold();
                               header.Cell().Element(CellStyle).AlignCenter().Text("Ücret").ExtraBold();
                               header.Cell().Element(CellStyle).AlignCenter().Text("Detaylar").ExtraBold();
                               header.Cell().Element(CellStyle).AlignCenter().Text("Ürün Adı").ExtraBold();
                               header.Cell().Element(CellStyle).AlignCenter().Text("Adet").ExtraBold();
                               // you can extend existing styles by creating additional methods
                               IContainer CellStyle(IContainer container) => DefaultCellStyle(container, Colors.Grey.Lighten3);


                           });

                           var deneme = reportDtos.ToList();
                           int sayac = 0;
                           for (uint i = 0; i < reportDtos.Count; i++)
                           {
                               table.Cell().Row(i + 1).Column(1).Element(CellStyle).Text(deneme[sayac].SupplierName ?? "-");
                               table.Cell().Row(i + 1).Column(2).Element(CellStyle).Text(deneme[sayac].OfferId.ToString() ?? "-");
                               table.Cell().Row(i + 1).Column(3).Element(CellStyle).Text(deneme[sayac].CreateDate ?? "-");
                               table.Cell().Row(i + 1).Column(4).Element(CellStyle).Text(deneme[sayac].Status.ToString() ?? "-");
                               table.Cell().Row(i + 1).Column(5).Element(CellStyle).Text(deneme[sayac].Price ?? "-");
                               table.Cell().Row(i + 1).Column(6).Element(CellStyle).Text(deneme[sayac].Detail ?? "-");
                               table.Cell().Row(i + 1).Column(7).Element(CellStyle).Text(deneme[sayac].Product ?? "-");
                               table.Cell().Row(i + 1).Column(8).Element(CellStyle).Text(deneme[sayac].Quantity ?? "-");

                               sayac++;
                           }

                           IContainer CellStyle(IContainer container) => DefaultCellStyle(container, Colors.Grey.Lighten3);
                       });

                    });
                });
                    
            })
        .GeneratePdf($"{yol + "\\"}{DateTime.Now.ToString().Replace(" ", "").Replace(".", "I").Replace(":", "I")}.pdf");


        }
    }
}
