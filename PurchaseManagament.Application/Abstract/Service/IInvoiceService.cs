using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Invoices;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface IInvoiceService
    {
        Task<Result<long>> CreateInvoice(CreateInvoiceRM create);
        Task<Result<long>> UpdateInvoice(UpdateInvoiceRM updateInvoiceRM);
        Task<Result<bool>> DeleteInvoice(GetByIdVM id);
        Task<Result<bool>> DeleteInvoicePermanent(GetByIdVM id);
        Task<Result<long>> UpdateInvoiceState(UpdateInvoiceStatusRM update);
        //GET METHODS

        Task<Result<InvoiceDto>> GetInvoiceById(GetInvoiceByIdRM getInvoiceById);
        Task<Result<HashSet<InvoiceDto>>> GetInvoicesByCompanyId(GetInvoiceByIdRM getInvoiceById);
        Task<Result<HashSet<InvoiceDto>>> GetPendingInvoicesByCompanyId(GetInvoiceByIdRM getInvoiceById);
        Task<Result<HashSet<InvoiceDto>>> GetAllInvoice();
        
    }
}
