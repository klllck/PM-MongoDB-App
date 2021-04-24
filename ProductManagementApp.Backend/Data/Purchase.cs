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

        [BsonElement("total_amount")]
        public int TotalAmount { get; set; }

        [BsonElement("total_price")]
        public double TotalPrice { get; set; }


        [BsonElement("product_id")]
        public string SupplierId { get; set; }

        [BsonElement("store_id")]
        public string StoreId { get; set; }
    }
}
