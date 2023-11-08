using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
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

        
        public async Task GeneratePDF(GetByIdVM getByIdVM)
        {
            var employeReports = await _reportService.GetReportByEmployeeId(getByIdVM);
           
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
                        .Height(2, Unit.Centimetre)
                        .AlignCenter()
                        .Text("Talep Dökümü")
                        .SemiBold().FontSize(22).FontColor(Colors.Black);

                    page.Content()
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
                            
                            table.Cell().Row(i+1).Column(1).Element(CellStyle).Text(deneme[sayac].RequestId.ToString());
                            table.Cell().Row(i+1).Column(2).Element(CellStyle).Text(deneme[sayac].Status.ToString());
                            table.Cell().Row(i+1).Column(3).Element(CellStyle).Text(deneme[sayac].Requestby.ToString());
                            table.Cell().Row(i+1).Column(4).Element(CellStyle).Text(deneme[sayac].Companydepartment.ToString());
                            table.Cell().Row(i+1).Column(5).Element(CellStyle).Text(deneme[sayac].product.ToString());
                            table.Cell().Row(i+1).Column(6).Element(CellStyle).Text(deneme[sayac].Quantity.ToString());
                            table.Cell().Row(i+1).Column(7).Element(CellStyle).Text(deneme[sayac].CreateDate.ToString());
                            table.Cell().Row(i+1).Column(8).Element(CellStyle).Text(deneme[sayac].ApprovedEmployee.ToString());
                            table.Cell().Row(i+1).Column(9).Element(CellStyle).Text(deneme[sayac].Prices.ToString());
                            table.Cell().Row(i+1).Column(10).Element(CellStyle).Text(deneme[sayac].supplier.ToString());
                            table.Cell().Row(i+1).Column(11).Element(CellStyle).Text(deneme[sayac].supplyDate.ToString());
                            table.Cell().Row(i+1).Column(12).Element(CellStyle).Text(deneme[sayac].InvoiceId.ToString());

                            sayac++;
                        }

                        IContainer CellStyle(IContainer container) => DefaultCellStyle(container, Colors.Grey.Lighten3);
                    });






                    page.Footer()
                        .AlignRight()
                        .Text(DateTime.Now.ToString())
                        .SemiBold().FontSize(16).FontColor(Colors.Black);

                });
            })
        .GeneratePdf(@$"C:\Users\sefa\Source\Repos\PurchaseManagament\PurchaseManagament.Application\Concrete\Services\PDFServices\PDFFiles\{DateTime.Now.ToString().Replace(" ", "").Replace(".", "I").Replace(":", "I")}.pdf");


        }

    }
}
