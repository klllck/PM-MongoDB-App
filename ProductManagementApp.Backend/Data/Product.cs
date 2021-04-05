using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace ProductManagementApp.Backend.Data
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Price { get; set; }
    }
}
