﻿using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Concrete.Services
{
    public class StockOperationsService : IStockOperationsService
    {
        public Task<Result<bool>> CreateStockOperations(StockOperationsDTO stockOperationsDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Result<HashSet<StockOperationsDTO>>> GetAllStockOperations()
        {
            throw new NotImplementedException();
        }
    }
}
