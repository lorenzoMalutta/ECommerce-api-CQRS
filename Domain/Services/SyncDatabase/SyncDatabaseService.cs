using agrolugue_api.Domain.Data.Context;
using agrolugue_api.Domain.ModelsQuery;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;

namespace agrolugue_api.Domain.Services.SyncDatabase
{
    public class DataSynchronizationService
    {
        private readonly DbContextOptions<PersistContext> _postgresOptions;
        private readonly ReadContext _mongoDatabase;

        public DataSynchronizationService(DbContextOptions<PersistContext> postgresOptions, ReadContext mongoDatabase)
        {
            _postgresOptions = postgresOptions;
            _mongoDatabase = mongoDatabase;
        }

        public async Task SynchronizeDataAsync()
        {
            using (var postgresContext = new PersistContext(_postgresOptions))
            {
                // Consultar os dados mais recentes do PostgreSQL
                var postgresProducts = await postgresContext.Products.ToListAsync();

                // Converter os objetos do PostgreSQL em objetos MongoDB (se necessário)
                var mongoProducts = postgresProducts.Select(p => new Product
                {
                   DateTime = DateTime.Now,
                   Description = p.Description,
                   Id = p.Id,
                   Name = p.Name,
                   OwnerId = p.OwnerId,
                   Price = p.Price
                }).ToList();

                // Inserir os objetos no MongoDB
                await _mongoDatabase.Products.InsertManyAsync(mongoProducts);
            }
        }
    }
}