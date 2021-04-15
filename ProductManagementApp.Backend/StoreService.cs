using MongoDB.Driver;
using ProductManagementApp.Backend.Data;
using ProductManagementApp.Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManagementApp.Backend
{
    public class StoreService : IStoreService
    {
        private readonly IMongoCollection<Store> _stores;

        public StoreService(IDbClient dbClient)
        {
            _stores = dbClient.GetStoresCollection();
        }

        public List<Store> GetAllStores()
        {
            return _stores.Find(s => true).ToList();
        }

        public Store GetStoreById(string id)
        {
            return _stores.Find(s => s.Id == id).First();
        }

        public Store AddStore(Store store)
        {
            _stores.InsertOne(store);
            return store;
        }

        public void DeleteStore(string id)
        {
            _stores.DeleteOne(p => p.Id == id);
        }

        public Store UpdateStore(Store store)
        {
            GetStoreById(store.Id);
            _stores.ReplaceOne(p => p.Id == store.Id, store);
            return store;
        }
    }
}
