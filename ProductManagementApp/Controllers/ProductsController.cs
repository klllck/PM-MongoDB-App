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
        private readonly ISupplierService _supplierService;

        public ProductsController(IProductService productService, IStoreService storeService, ISupplierService supplierService)
        {
            _productService = productService;
            _storeService = storeService;
            _supplierService = supplierService;
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
            var suppliers = _supplierService.GetAllSuppliers();

            var model = new ProductViewModel
            {
                Stores = stores,
                Suppliers = suppliers
            };
            return View(model);
        }

        [HttpPost, ActionName("Create")]
        public IActionResult Add(ProductViewModel productViewModel)
        {
            var product = new Product
            {
                Name = productViewModel.Name,
                Amount = productViewModel.Amount,
                Price = productViewModel.Price,
                StoreId = productViewModel.StoreId,
                SupplierId = productViewModel.SupplierId
            };

            _productService.AddProduct(product);

            return Redirect("/products");
        }

        [HttpGet("/products/delete/{id}")]
        public IActionResult Delete(string id)
        {
            _productService.DeleteProduct(id);
            return Redirect("/products");
        }

        [HttpGet("/products/update/{id}")]
        public IActionResult Update(string id)
        {
            if (id != null)
            {
                var product = _productService.GetProductById(id);
                var stores = _storeService.GetAllStores();
                var suppliers = _supplierService.GetAllSuppliers();

                var model = new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Amount = product.Amount,
                    Price = product.Price,
                    Stores = stores,
                    Suppliers = suppliers
                };
                return View(model);
            }
            else return NotFound();
        }

        [HttpPost]
        public IActionResult Update(ProductViewModel productViewModel)
        {
            var product = new Product
            {
                Id = productViewModel.Id,
                Name = productViewModel.Name,
                Amount = productViewModel.Amount,
                Price = productViewModel.Price,
                StoreId = productViewModel.StoreId,
                SupplierId = productViewModel.SupplierId
            };

            _productService.UpdateProduct(product);

            return Redirect("/products");
        }
    }
}
