using agrolugue_api.Domain.Auth;
using agrolugue_api.Domain.ModelsQuery;
using MongoDB.Driver;

namespace agrolugue_api.Domain.Data.Context
{
    public class ReadContext
    {
        private readonly IMongoDatabase _mongo;
        public ReadContext(IConfiguration configuration)
        {
            var settings = MongoClientSettings.FromConnectionString(configuration["Mongo:ConnectionString"]);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            _mongo = client.GetDatabase(configuration["DatabaseName"]);
        }

        public IMongoCollection<Product> Products => _mongo.GetCollection<Product>("Product");
        public IMongoCollection<Rent> Rents => _mongo.GetCollection<Rent>("Rent");
        public IMongoCollection<User> Users => _mongo.GetCollection<User>("User");
    }
}
