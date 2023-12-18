using AutoMapper;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Pages;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Domain.Abstract;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Persistence.Abstract.UnitWork;

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
            var entity=await _uwork.GetRepository<PageRole>().GetByFilterAsync(x=>_loggedService.Role.Contains(x.RoleId), "Page") /*x.RoleId==_loggedService.Role.Select(*/;
           // var entity = await _uwork.GetRepository<Page>().GetByFilterAsync(x => x.UpperPageId == null, "LowerPages");
            var dtos = _mapper.Map<HashSet<PageDto>>(entity);
            result.Data = dtos;
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
