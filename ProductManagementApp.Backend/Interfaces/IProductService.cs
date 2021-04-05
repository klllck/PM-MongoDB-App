using ProductManagementApp.Backend.Data;
using System.Collections.Generic;

namespace ProductManagementApp.Backend.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetProductById(string id);
        Product AddProduct(Product product);
        Product UpdateProduct(Product product);
        void DeleteProduct(string product);
    }
}
