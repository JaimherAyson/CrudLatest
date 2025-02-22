using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CrudLatest.Server.Shared.Models
{
    public class Item
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("color")]
        public string Color { get; set; } = string.Empty;

        [BsonElement("price")]
        public decimal Price { get; set; } = 0.0m;
    }
}
