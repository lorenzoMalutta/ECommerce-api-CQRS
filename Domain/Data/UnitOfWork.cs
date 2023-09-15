using agrolugue_api.Domain.Data.Context;

namespace agrolugue_api.Domain.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PersistContext _persistContext;

        public UnitOfWork(PersistContext persistContext)
        {
            _persistContext = persistContext;
        }

        public void Commit()
        {
            _persistContext.SaveChanges();
        }

        public void Rollback()
        {
            //
        }
    }
}
