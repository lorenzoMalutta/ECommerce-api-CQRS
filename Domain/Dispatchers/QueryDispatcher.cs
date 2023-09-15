using CQRS101.Common;

namespace CQRS101.Dispatchers
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public Task<TQueryResult> Dispatch<TQuey, TQueryResult>(TQuey query, CancellationToken cancellation)
        {
            var handler = _serviceProvider.GetRequiredService<IQueryHandler<TQuey, TQueryResult>>();

            return handler.Handle(query, cancellation);
        }
    }
}
