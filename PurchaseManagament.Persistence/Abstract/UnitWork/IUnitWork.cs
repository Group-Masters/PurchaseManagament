using PurchaseManagament.Persistence.Abstract.Repository;

namespace PurchaseManagament.Persistence.Abstract.UnitWork
{
    public interface IUnitWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;
        Task<bool> CommitAsync();
        bool Commit();
    }
}
