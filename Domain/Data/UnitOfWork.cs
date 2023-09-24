using agrolugue_api.Domain.Data.Context;
using agrolugue_api.Domain.Services.SyncDatabase;

namespace agrolugue_api.Domain.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PersistContext _persistContext;
        private readonly DataSynchronizationService _syncDatabase;

        public UnitOfWork(PersistContext persistContext, DataSynchronizationService syncDatabase)
        {
            _persistContext = persistContext;
            _syncDatabase = syncDatabase;
        }

        public async void Commit()
        {
            _persistContext.SaveChanges();
           await _syncDatabase.SynchronizeDataAsync();
        }

        public void Rollback()
        {
            //
        }
    }
}
