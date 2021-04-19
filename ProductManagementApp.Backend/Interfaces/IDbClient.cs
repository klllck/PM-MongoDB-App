using MongoDB.Driver;
using ProductManagementApp.Backend.Data;

namespace ProductManagementApp.Backend.Interfaces
{
    public interface IDbClient
    {
        IMongoCollection<Product> GetProductsCollection();
        IMongoCollection<Store> GetStoresCollection();
        IMongoCollection<Supplier> GetSuppliersCollection();
        IMongoCollection<Purchase> GetPurchasesCollection();
    }
}
