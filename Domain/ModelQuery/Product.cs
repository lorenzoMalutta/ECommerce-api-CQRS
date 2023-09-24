using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace agrolugue_api.Domain.ModelsQuery
{
    public class Product
    {
        [BsonId]
        public string Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime DateTime { get; set; }

        public string OwnerId { get; set; }
        public virtual User Owner { get; set; }

        public virtual ICollection<Rent> RentedProducts { get; set; } = new List<Rent>();
    }
}
