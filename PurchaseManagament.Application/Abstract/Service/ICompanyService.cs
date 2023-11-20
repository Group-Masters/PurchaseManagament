using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Companies;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Wrapper;
using System.Dynamic;
using System.Linq.Expressions;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface ICompanyService : IDynamicMetaObjectProvider
    {
        //CRUD
        Task<Result<bool>> CreateCompany(CreateCompanyRM createCompanyRM);
        Task<Result<bool>> UpdateCompany(UpdateCompanyRM updateCompanyRM);
        Task<Result<bool>> DeleteCompanyPermanent(GetByIdVM Id);
        Task<Result<bool>> DeleteCompany(GetByIdVM Id);

        //GET METHODS
        Task<Result<CompanyDto>> GetCompanyById(GetCompanyByIdRM getCompanyByIdRM);
        Task<Result<HashSet<CompanyDto>>> GetAllCompany();

        DynamicMetaObject GetMetaObject(Expression target);
    }
}
