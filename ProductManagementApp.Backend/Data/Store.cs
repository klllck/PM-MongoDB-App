﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductManagementApp.Backend.Data
{
    public class Store
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("address")]
        public string Address { get; set; }

        [BsonElement("phone")]
        public string Phone { get; set; }

        [BsonElement("postal_code")]
        public string PostalCode { get; set; }
    }
}
