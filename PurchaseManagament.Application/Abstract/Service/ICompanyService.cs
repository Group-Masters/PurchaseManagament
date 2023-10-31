using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Companies;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface ICompanyService
    {
        //CRUD
        Task<Result<bool>> CreateCompany(CreateCompanyRM createCompanyRM);
        Task<Result<bool>> DeleteCompany(DeleteCompanyRM deleteCompanyRM); 
        Task<Result<bool>> UpdateCompany(UpdateCompanyRM updateCompanyRM);

        //GET METHODS
        Task<Result<CompanyDto>> GetCompanyByName(string companyName);
        Task<Result<HashSet<CompanyDto>>> GetAllCompany();
    }
}
