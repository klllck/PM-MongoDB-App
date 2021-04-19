using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ProductManagementApp.Backend.Data
{
    public class Purchase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("date_time")]
        public DateTime Date { get; set; }

        [BsonElement("amount")]
        public int Amount { get; set; }

        [BsonElement("price")]
        public double Price { get; set; }


        [BsonElement("supplier_id")]
        public string SupplierId { get; set; }
    }
}
