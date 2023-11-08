using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Concrete.Models.RequestModels.ImgProduct
{
    public class CreateImgProductRM
    {
        public Int64 ProductId { get; set; }
        public string ImageSrc { get; set; }
    }
}
