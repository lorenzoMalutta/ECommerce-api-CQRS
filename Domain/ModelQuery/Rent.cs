using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace agrolugue_api.Domain.ModelsQuery
{
    public class Rent
    {
        [BsonId]
        public string Id { get; set; }

        public DateTimeOffset RentDay { get; set; }
        public DateTimeOffset RentDeadLine { get; set; }

        public string ProductId { get; set; }
        public virtual Product Product { get; set; }

        public string UserRentId { get; set; }
        public virtual User UserRent { get; set; }
    }
}
