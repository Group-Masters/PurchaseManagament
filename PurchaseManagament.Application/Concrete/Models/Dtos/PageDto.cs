using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Concrete.Models.Dtos
{
    public class PageDto
    {
        public string Url { get; set; }
        public string PageName { get; set; }
        public string Content { get; set; }

        public ICollection<PageDto> LowerPages { get; set; }
    }
}
