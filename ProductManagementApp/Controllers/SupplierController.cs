using Microsoft.AspNetCore.Mvc;
using ProductManagementApp.Backend.Data;
using ProductManagementApp.Backend.Interfaces;
using ProductManagementApp.ViewModels;
using System.Linq;

namespace ProductManagementApp.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;
        private readonly IProductService _productService;

        public SupplierController(ISupplierService supplierService, IProductService productService)
        {
            _supplierService = supplierService;
            _productService = productService;
        }

        [HttpGet("/suppliers")]
        public IActionResult GetAll()
        { 
            var model = _supplierService.GetAllSuppliers();
            return View("List", model);
        }

        [HttpGet("/suppliers/details")]
        public IActionResult Details()
        {
            var model = new SupplierViewModel
            {
                Suppliers = _supplierService.GetAllSuppliers()
            };
            return View(model);
        }

        [HttpPost("/suppliers/details")]
        public IActionResult Details(SupplierViewModel supplierViewModel)
        {
            var supplierId = supplierViewModel.SupplierId;
            var products = _productService.GetAllProducts().FindAll(p => p.SupplierId == supplierId);

            var productsModel = products.Select(p => new ProductViewModel
            {
                Name = p.Name,
                Price = p.Price,
                DiscountPrice = p.Price - (p.Price * 0.2)
            });

            supplierViewModel.Products = productsModel;
            supplierViewModel.Suppliers = _supplierService.GetAllSuppliers();

            return View(supplierViewModel);
        }

        [HttpGet("suppliers/{id}")]
        public IActionResult GetById(string id)
        {
            return Ok(_supplierService.GetSupplierById(id));
        }

        [HttpPost("suppliers/add")]
        public IActionResult Add(Supplier supplier)
        {
            return Ok(_supplierService.AddSupplier(supplier));
        }

        //[HttpPost, ActionName("Create")]
        //public IActionResult Add(ProductViewModel productViewModel)
        //{
        //    var product = new Product
        //    {
        //        Name = productViewModel.Name,
        //        Price = productViewModel.Price,
        //        StoreId = productViewModel.StoreId
        //    };

        //    _productService.AddProduct(product);

        //    return Redirect("~/Home/Index");
        //}

        //[HttpDelete]
        //public IActionResult Delete(string id)
        //{
        //    _supplierService.DeleteSupplier(id);
        //    return NoContent();
        //}

        //[HttpPut]
        //public IActionResult Update(Supplier supplier)
        //{
        //    return Ok(_supplierService.UpdateSupplier(supplier));
        //}
    }
}
