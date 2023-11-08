using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Concrete.Models.Dtos
{
    public class ImgProductDto
    {
        public Int64 Id { get; set; }
        public Int64 ProductId { get; set; }
        public string ImageSrc { get; set; }
    }
}
