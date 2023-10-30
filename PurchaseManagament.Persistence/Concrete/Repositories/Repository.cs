using Microsoft.EntityFrameworkCore;
using PurchaseManagament.Persistence.Abstract.Repository;
using PurchaseManagament.Persistence.Concrete.Context;
using System.Linq.Expressions;

namespace PurchaseManagament.Persistence.Concrete.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly PurchaseManagamentContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(PurchaseManagamentContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        public  async Task<bool> AnyAsync(Expression<Func<T, bool>> filter )
        {
            var result = await EF.CompileAsyncQuery((PurchaseManagamentContext ctx) => ctx.Set<T>().Any(filter)).Invoke( _context);
            return result;
        }
  
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var entities =  EF.CompileAsyncQuery((PurchaseManagamentContext ctx) => ctx.Set<T>()).Invoke(_context).ToBlockingEnumerable();
            
            return  entities;
        }

        public async Task<IEnumerable<T>> GetAllAsyncAsNoTracking()
        {
            var entities = EF.CompileAsyncQuery((PurchaseManagamentContext ctx) => ctx.Set<T>().AsNoTracking()).Invoke(_context).ToBlockingEnumerable();
            return entities;
        }

        public async Task<IEnumerable<T>> GetByFilter(Expression<Func<T, bool>> filter = null)
        {
            var entities = await EF.CompileAsyncQuery((PurchaseManagamentContext ctx) => ctx.Set<T>().Where(filter).AsEnumerable()).Invoke(_context);
            return entities;
        }

        public async Task<IEnumerable<T>> GetByFilterAsNoTracking(Expression<Func<T, bool>> filter = null)
        {
            var entities = await EF.CompileAsyncQuery((PurchaseManagamentContext ctx) => ctx.Set<T>().Where(filter).AsNoTracking().AsEnumerable()).Invoke(_context);
            return entities;
        }

        public async Task<T> GetById(Object id)
        {
           var entity = await EF.CompileAsyncQuery((PurchaseManagamentContext ctx) => ctx.Set<T>().FindAsync(id)).Invoke(_context).Result;
            return entity;
        }

        public async Task<T> GetBySpesificFilter(Expression<Func<T, bool>> filter = null)
        {
            var entity = await EF.CompileAsyncQuery((PurchaseManagamentContext ctx) => ctx.Set<T>().FindAsync(filter).Result).Invoke(_context);
            return entity;
        }

        public async Task<T> GetBySpesificFilterAsNoTracking(Expression<Func<T, bool>> filter = null)
        {
            var entity = await EF.CompileAsyncQuery((PurchaseManagamentContext ctx) => ctx.Set<T>().AsNoTracking().Where(filter).First()).Invoke(_context);
            return entity;
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
