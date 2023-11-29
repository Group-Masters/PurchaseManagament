using PurchaseManagament.Application.Concrete.Models.Dtos.ChartDtos;
using PurchaseManagament.Application.Concrete.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface IChartService
    {
        Task<Result<MainChartDto>> GetMainChart();
        Task<Result<List<ChartDto>>> GetChartCompanyRequest();
    }
}
