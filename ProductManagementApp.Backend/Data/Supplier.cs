using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductManagementApp.Backend.Data
{
    public class Supplier
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("phone")]
        public string Phone { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }


        [BsonElement("store_id")]
        public string StoreId { get; set; }
    }
}
