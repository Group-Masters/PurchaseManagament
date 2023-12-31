﻿using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Companies;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface ICompanyService
    {
        //CRUD
        Task<Result<bool>> CreateCompany(CreateCompanyRM createCompanyRM);
        Task<Result<bool>> UpdateCompany(UpdateCompanyRM updateCompanyRM);
        Task<Result<bool>> DeleteCompanyPermanent(GetByIdVM Id);
        Task<Result<bool>> DeleteCompany(GetByIdVM Id);

        //GET METHODS
        Task<Result<CompanyDto>> GetCompanyById(GetCompanyByIdRM getCompanyByIdRM);
        Task<Result<HashSet<CompanyDto>>> GetAllCompany();
    }
}
