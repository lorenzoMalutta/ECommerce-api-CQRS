namespace agrolugue_api.Domain.Data.Repository
{
    public interface IQueries<T>
    {
        Task<IEnumerable<T>> GetAll(int skip = 0, int take = 10);
        Task<T> FindById(string id);
    }
}
