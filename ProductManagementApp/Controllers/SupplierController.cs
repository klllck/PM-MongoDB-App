using Microsoft.AspNetCore.Mvc;
using ProductManagementApp.Backend.Data;
using ProductManagementApp.Backend.Interfaces;
using ProductManagementApp.ViewModels;
using System;
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
            var supplier = _supplierService.GetSupplierById(supplierId);
            var products = _productService.GetAllProducts().FindAll(p => p.SupplierId == supplierId);

            var productsModel = products.Select(p => new ProductViewModel
            {
                Name = p.Name,
                Price = p.Price,
                DiscountPrice = Math.Round(p.Price - p.Price * 0.2, 2)
            });

            if (supplier != null)
            {
                supplierViewModel.SupplierName = supplier.Name;
                supplierViewModel.SupplierDescription = supplier.Description;
                supplierViewModel.SupplierPhone = supplier.Phone;
                supplierViewModel.SupplierEmail = supplier.Email;
                supplierViewModel.Products = productsModel;
                supplierViewModel.Suppliers = _supplierService.GetAllSuppliers();
            }

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
    }
}
