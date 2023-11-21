using PurchaseManagament.Persistence.Abstract.Repository;
using PurchaseManagament.Persistence.Abstract.UnitWork;
using PurchaseManagament.Persistence.Concrete.Context;
using PurchaseManagament.Persistence.Concrete.Repositories;

namespace PurchaseManagament.Persistence.Concrete.UnitWork
{
    public class UnitWork : IUnitWork
    {
        private readonly PurchaseManagamentContext _context;
        private Dictionary<Type, object> _repositories;
        private bool disposedValue = false;

        public UnitWork(PurchaseManagamentContext context)
        {
            _repositories = new Dictionary<Type, object>();
            _context = context ?? throw new Exception("Nesne gelmedi");
        }

        

        public async Task<bool> CommitAsync()
        {
            var result = false;

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    result = true;
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
            return result;
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            //Daha önce bu repoyu talep eden bir kullanıcı olmuşsa aynı repoyu tekrar üretmez.
            //Burada sakladığı koleksiyon içerisinden gönderir. Bu da performansı artırır.
            if (_repositories.ContainsKey(typeof(IRepository<T>)))
            {
                return (IRepository<T>)_repositories[typeof(IRepository<T>)];
            }

            var repository = new Repository<T>(_context);
            _repositories.Add(typeof(IRepository<T>), repository);
            return repository;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                    // TODO: yönetilen durumu (yönetilen nesneleri) atın
                }

                // TODO: yönetilmeyen kaynakları (yönetilmeyen nesneleri) serbest bırakın ve sonlandırıcıyı geçersiz kılın
                // TODO: büyük alanları null olarak ayarlayın
                disposedValue = true;
            }
        }

        // // TODO: sonlandırıcıyı yalnızca 'Dispose(bool disposing)' içinde yönetilmeyen kaynakları serbest bırakacak kod varsa geçersiz kılın
        // ~UnitWork()
        // {
        //     // Bu kodu değiştirmeyin. Temizleme kodunu 'Dispose(bool disposing)' metodunun içine yerleştirin.
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Bu kodu değiştirmeyin. Temizleme kodunu 'Dispose(bool disposing)' metodunun içine yerleştirin.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
