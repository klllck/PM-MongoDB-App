using MongoDB.Driver;
using ProductManagementApp.Backend.Data;
using ProductManagementApp.Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManagementApp.Backend
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IMongoCollection<Purchase> _purchases;

        public PurchaseService(IDbClient dbClient)
        {
            _purchases = dbClient.GetPurchasesCollection();
        }

        public List<Purchase> GetAllPurchases()
        {
            return _purchases.Find(p => true).ToList();
        }

        public Purchase GetPurchaseById(string id)
        {
            return _purchases.Find(p => p.Id == id).FirstOrDefault();
        }

        public Purchase AddPurchase(Purchase purchase)
        {
            _purchases.InsertOne(purchase);
            return purchase;
        }

        public void DeletePurchase(string id)
        {
            _purchases.DeleteOne(p => p.Id == id);
        }

        public Purchase UpdatePurchase(Purchase purchase)
        {
            _purchases.ReplaceOne(p => p.Id == purchase.Id, purchase);
            return purchase;
        }
    }
}
