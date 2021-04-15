﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

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
        public double Amount { get; set; }

        [BsonElement("price")]
        public double Price { get; set; }


        [BsonElement("store_id")]
        public string StoreId { get; set; }
    }
}
