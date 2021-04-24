using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductManagementApp.Backend.Data
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("amount")]
        public int Amount { get; set; }

        [BsonElement("price")]
        public double Price { get; set; }


        [BsonElement("store_id")]
        public string StoreId { get; set; }

        [BsonElement("supplier_id")]
        public string SupplierId { get; set; }

        [BsonElement("purchase_id")]
        public string PurchaseId { get; set; }
    }
}
