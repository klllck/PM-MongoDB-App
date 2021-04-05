using MongoDB.Driver;
using ProductManagementApp.Backend.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManagementApp.Backend.Interfaces
{
    public interface IDbClient
    {
        IMongoCollection<Product> GetProductsCollection();
    }
}
