using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Persistence.Abstract.UnitWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Concrete.Services
{
    public class PageService : IPageService
    {
        private readonly IUnitWork _uwork;
        private readonly IMapper _mapper;

        public PageService(IUnitWork uwork, IMapper mapper)
        {
            _uwork = uwork;
            _mapper = mapper;
        }
        public async Task<Result<HashSet<PageDto>>> GetAllPage()
        {
            var result = new Result<HashSet<PageDto>>();
            var entity = await _uwork.GetRepository<Page>().GetByFilterAsync(x=>x.UpperPageId==null, "LowerPages");
            var dtos = _mapper.Map<HashSet<PageDto>>(entity);
            result.Data= dtos;
            return result;
        }
    }
}
