using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Companies;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface ICompanyService
    {
        Task<Result<bool>> CreateCompany(CreateCompanyRM createCompanyRM);
        Task<Result<HashSet<CompanyDto>>> GetAllCompany();
    }
}
