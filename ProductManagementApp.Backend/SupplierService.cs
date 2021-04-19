using MongoDB.Driver;
using ProductManagementApp.Backend.Data;
using ProductManagementApp.Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManagementApp.Backend
{
    public class SupplierService : ISupplierService
    {
        private readonly IMongoCollection<Supplier> _suppliers;

        public SupplierService(IDbClient dbClient)
        {
            _suppliers = dbClient.GetSuppliersCollection();
        }

        public List<Supplier> GetAllSuppliers()
        {
            return _suppliers.Find(s => true).ToList();
        }

        public Supplier GetSupplierById(string id)
        {
            return _suppliers.Find(s => s.Id == id).FirstOrDefault();
        }

        public Supplier AddSupplier(Supplier supplier)
        {
            _suppliers.InsertOne(supplier);
            return supplier;
        }

        public void DeleteSupplier(string supplierId)
        {
            _suppliers.DeleteOne(s => s.Id == supplierId);
        }

        public Supplier UpdateSupplier(Supplier supplier)
        {
            _suppliers.ReplaceOne(s => s.Id == supplier.Id, supplier);
            return supplier;
        }
    }
}
