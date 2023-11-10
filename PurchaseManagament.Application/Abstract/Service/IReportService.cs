using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Report;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface IReportService
    {
        Task<Result<HashSet<ReportDto>>> GetReportByEmployeeId(GetByIdVM getByIdVM);
        Task<Result<HashSet<ReportDto>>> GetReportByDepartmentId(GetByIdVM getByIdVM);
        Task<Result<HashSet<ReportDto>>> GetReportByCompanyId(GetByIdVM getByIdVM);
        Task<Result<HashSet<ReportDto>>> GetProductReport(GetReportProductVM getReportProductVM);
        Task<Result<HashSet<ReportSupplierDto>>> GetSupplierReport(GetByIdVM getByIdVM);

    }
}
