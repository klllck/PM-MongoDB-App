using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProductManagementApp.Backend.Data;
using ProductManagementApp.Backend.Interfaces;

namespace ProductManagementApp.Backend
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<Product> _products;
        private readonly IMongoCollection<Store> _stores;
        private readonly IMongoCollection<Supplier> _suppliers;
        private readonly IMongoCollection<Purchase> _purchases;

        public DbClient(IOptions<AppDbConfig> appDbConfig)
        {
            var client = new MongoClient(appDbConfig.Value.Connection_String);
            var database = client.GetDatabase(appDbConfig.Value.Database_Name);

            _products = database.GetCollection<Product>(appDbConfig.Value.Products_Collection_Name);
            _stores = database.GetCollection<Store>(appDbConfig.Value.Stores_Collection_Name);
            _suppliers = database.GetCollection<Supplier>(appDbConfig.Value.Suppliers_Collection_Name);
            _purchases = database.GetCollection<Purchase>(appDbConfig.Value.Purchases_Collection_Name);
        }

        public IMongoCollection<Product> GetProductsCollection() => _products;

        public IMongoCollection<Purchase> GetPurchasesCollection() => _purchases;

        public IMongoCollection<Store> GetStoresCollection() => _stores;

        public IMongoCollection<Supplier> GetSuppliersCollection() => _suppliers;
    }
}
