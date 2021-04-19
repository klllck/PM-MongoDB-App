using Microsoft.AspNetCore.Mvc;
using ProductManagementApp.Backend.Data;
using ProductManagementApp.Backend.Interfaces;
using ProductManagementApp.ViewModels;

namespace ProductManagementApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IStoreService _storeService;

        public ProductsController(IProductService productService, IStoreService storeService)
        {
            _productService = productService;
            _storeService = storeService;
        }

        [HttpGet("products")]
        public IActionResult GetAll()
        {
            var model = _productService.GetAllProducts();
            return View("List", model);
        }

        [HttpGet("products/details/{id}")]
        public IActionResult Detail(string id)
        {
            return Ok(_productService.GetProductById(id));
        }

        [HttpGet("/products/create")]
        public IActionResult Create()
        {
            var stores = _storeService.GetAllStores();

            var model = new ProductViewModel
            {
                Stores = stores
            };
            return View(model);
        }

        [HttpPost, ActionName("Create")]
        public IActionResult Add(ProductViewModel productViewModel)
        {
            var product = new Product
            {
                Name = productViewModel.Name,
                Price = productViewModel.Price,
                StoreId = productViewModel.StoreId
            };

            _productService.AddProduct(product);

            return Redirect("~/Home/Index");
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            _productService.DeleteProduct(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Update(Product product)
        {
            return Ok(_productService.UpdateProduct(product));
        }
    }
}
