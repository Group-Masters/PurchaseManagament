using PurchaseManagament.Domain.Entities;

namespace PurchaseManagament.Application.Concrete.Models.Dtos
{
    public class ProductDto
    {
        public long Id { get; set; }
        public long MeasuringUnitId { get; set; }
        public string MeasuringName{ get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgProduct { get; set; }
    }
}
