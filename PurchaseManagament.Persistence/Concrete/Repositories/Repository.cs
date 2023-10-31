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
        public async Task<IQueryable<T>> GetAllAsync(params string[] includeColumns)
        {
            IQueryable<T> query = _dbSet;

            if (includeColumns.Any())
            {
                foreach (var includeColumn in includeColumns)
                {
                    query = query.Include(includeColumn);
                }
            }
            return await Task.FromResult(query);
        }

        public async Task<IQueryable<T>> GetByFilterAsync(Expression<Func<T, bool>> filter, params string[] includeColumns)
        {
            IQueryable<T> query = _dbSet;

            if (includeColumns.Any())
            {
                foreach (var includeColumn in includeColumns)
                {
                    query = query.Include(includeColumn);
                }
            }
            return await Task.FromResult(query.Where(filter));
        }

        public async Task<T> GetSingleByFilterAsync(Expression<Func<T, bool>> filter, params string[] includeColumns)
        {
            IQueryable<T> query = _dbSet;

            if (includeColumns.Any())
            {
                foreach (var includeColumn in includeColumns)
                {
                    query = query.Include(includeColumn);
                }
            }
            return await query.FirstOrDefaultAsync(filter);
        }

        public async Task<T> GetById(object id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.AnyAsync(filter);
        }


        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Delete(object id)
        {
            var item = _dbSet.Find(id);
            _dbSet.Remove(item);
        }

    }
}
