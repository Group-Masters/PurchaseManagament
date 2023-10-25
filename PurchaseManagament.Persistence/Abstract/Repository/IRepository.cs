using System.Linq.Expressions;

namespace PurchaseManagament.Persistence.Abstract.Repository
{
    public interface IRepository<T> 
        where T : class
    {
        //CRUD
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        //MODİFİED GETS
        #region Pure Get Methods
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsyncAsNoTracking();
        #endregion

        #region GetById Methods
        Task<T> GetById(Object id);
        #endregion

        #region GetByFilter Methods
        Task<T> GetBySpesificFilter(Expression<Func<T, bool>> filter = null);
        Task<IEnumerable<T>> GetByFilter(Expression<Func<T, bool>> filter = null);
        Task<T> GetBySpesificFilterAsNoTracking(Expression<Func<T, bool>> filter = null);
        Task<IEnumerable<T>> GetByFilterAsNoTracking(Expression<Func<T, bool>> filter = null);

        #endregion




    }
}
