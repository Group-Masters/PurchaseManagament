﻿using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Pages;
using PurchaseManagament.Application.Concrete.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Abstract.Service
{
    public interface IPageService
    {
        Task<Result<HashSet<PageDto>>> GetAllPage();
        Task<Result<bool>> CreatePage(CreatePageVM addPageVM);
        Task<Result<bool>> PageAddRole(PageAddRoleVM pageAddRoleVM);
        
    }
}
