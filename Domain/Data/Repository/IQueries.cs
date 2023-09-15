namespace agrolugue_api.Domain.Data.Repository
{
    public interface IQueries<T>
    {
        IEnumerable<T> GetAll(int skip = 0, int take = 10);
        T FindById(int id);
    }
}
