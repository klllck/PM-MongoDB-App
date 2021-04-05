using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProductManagementApp.Backend.Data;
using ProductManagementApp.Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManagementApp.Backend
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<Product> _products;

        public DbClient(IOptions<AppDbConfig> appDbConfig)
        {
            var client = new MongoClient(appDbConfig.Value.Connection_String);
            var database = client.GetDatabase(appDbConfig.Value.Database_Name);
            _products = database.GetCollection<Product>(appDbConfig.Value.Products_Collection_Name);
        }

        public IMongoCollection<Product> GetProductsCollection() => _products;
    }
}
