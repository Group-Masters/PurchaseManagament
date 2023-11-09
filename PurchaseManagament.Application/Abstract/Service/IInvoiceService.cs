using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Invoices;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Offers;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface IInvoiceService
    {
        Task<Result<long>> CreateInvoice(CreateInvoiceRM create);
        Task<Result<long>> UpdateInvoice(UpdateInvoiceRM updateInvoiceRM);
        Task<Result<bool>> DeleteInvoice(Int64 id);
        Task<Result<bool>> DeleteInvoicePermanent(Int64 id);
        Task<Result<long>> UpdateInvoiceState(UpdateInvoiceStatusRM update);
        //GET METHODS

        Task<Result<InvoiceDto>> GetInvoiceById(GetInvoiceByIdRM getInvoiceById);
        Task<Result<HashSet<InvoiceDto>>> GetInvoicesByCompanyId(GetInvoiceByIdRM getInvoiceById);
        Task<Result<HashSet<InvoiceDto>>> GetAllInvoice();
        
    }
}
