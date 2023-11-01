﻿using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Companies;
using PurchaseManagament.Application.Concrete.Wrapper;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface ICompanyService
    {
        //CRUD
        Task<Result<bool>> CreateCompany(CreateCompanyRM createCompanyRM);
        Task<Result<bool>> UpdateCompany(UpdateCompanyRM updateCompanyRM);
        Task<Result<bool>> DeleteCompanyPermanent(Int64 Id);
        Task<Result<bool>> DeleteCompany(Int64 Id);

        //GET METHODS
        Task<Result<CompanyDto>> GetCompanyById(GetCompanyByIdRM getCompanyByIdRM);
        Task<Result<HashSet<CompanyDto>>> GetAllCompany();
    }
}
