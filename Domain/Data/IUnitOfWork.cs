namespace agrolugue_api.Domain.Data
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}
