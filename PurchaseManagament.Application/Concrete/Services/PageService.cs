﻿using AutoMapper;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Pages;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Domain.Abstract;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Persistence.Abstract.UnitWork;
using System.Linq;

namespace PurchaseManagament.Application.Concrete.Services
{
    public class PageService : IPageService
    {
        private readonly IUnitWork _uwork;
        private readonly IMapper _mapper;
        private readonly ILoggedService _loggedService;

        public PageService(IUnitWork uwork, IMapper mapper, ILoggedService loggedService)
        {
            _uwork = uwork;
            _mapper = mapper;
            _loggedService = loggedService;
        }
        public async Task<Result<bool>> CreatePage(CreatePageVM addPageVM)
        {
            var result = new Result<bool>();
            var entity = _mapper.Map<Page>(addPageVM);
            _uwork.GetRepository<Page>().Add(entity);
            result.Data = await _uwork.CommitAsync();
            return result;

        }
        public async Task<Result<HashSet<PageDto>>> GetAllPage()
        {

            var result = new Result<HashSet<PageDto>>();
            var UpperEntity = await _uwork.GetRepository<Page>()
           .GetByFilterAsync(x => x.PageRoles.Any(y => _loggedService.Role.Contains(y.RoleId)) && x.UpperPage == null)
           .ConfigureAwait(false);
            
            
            var upperdtos = _mapper.Map<HashSet<PageDto>>(UpperEntity);
            foreach (var item in upperdtos)
            {
                var entity  = await _uwork.GetRepository<Page>().GetByFilterAsync(x => x.PageRoles.Any(y => _loggedService.Role.Contains(y.RoleId)) && x.UpperPageId == item.Id)
                .ConfigureAwait(false);
                if (entity != null)
                {
                    //var   entity2 = entity.ToList();
                    var entitydtos = _mapper.Map<HashSet<PageDto>>(entity);


                    item.LowerPages = entitydtos;
                }
            }

          //var upperdtos = _mapper.Map<HashSet<PageDto>>(UpperEntity);

          //       var entity = await _uwork.GetRepository<PageRole>()
          //.GetByFilterAsync(x =>
          //    _loggedService.Role.Contains(x.RoleId) &&
          //    x.Page.LowerPages.Any(lp =>
          //        lp.PageRoles.Any(pr =>
          //            _loggedService.Role.Contains(pr.RoleId)
          //        )
          //    ), "Page.LowerPages"
          //);
          /*x.RoleId==_loggedService.Role.Select(*/
          // var entity = await _uwork.GetRepository<Page>().GetByFilterAsync(x => x.UpperPageId == null, "LowerPages");
          
            result.Data = upperdtos;
            return result;
        }
        public async Task<Result<bool>> PageAddRole(PageAddRoleVM pageAddRoleVM)
        {
            var result = new Result<bool>();
            var entity = _mapper.Map<PageRole>(pageAddRoleVM);
            _uwork.GetRepository<PageRole>().Add(entity);
            result.Data = await _uwork.CommitAsync();
            return result;
        }
    }
}
