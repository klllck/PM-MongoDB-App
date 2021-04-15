using MongoDB.Driver;
using ProductManagementApp.Backend.Data;
using ProductManagementApp.Backend.Interfaces;
using System;
using System.Collections.Generic;

namespace ProductManagementApp.Backend
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _products;

        public ProductService(IDbClient dbClient)
        {
            _products = dbClient.GetProductsCollection();
        }
        public List<Product> GetAllProducts()
        {
            return _products.Find(p => true).ToList();
        }

        public Product GetProductById(string id)
        {
            return _products.Find(p => p.Id == id).First();
        }

        public Product AddProduct(Product product)
        {
            _products.InsertOne(product);
            return product;
        }

        public void DeleteProduct(string id)
        {
            _products.DeleteOne(p => p.Id == id);
        }

        public Product UpdateProduct(Product product)
        {
            GetProductById(product.Id);
            _products.ReplaceOne(p => p.Id == product.Id, product);
            return product;
        }
    }
}
