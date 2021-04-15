using Microsoft.AspNetCore.Mvc;
using ProductManagementApp.Backend.Data;
using ProductManagementApp.Backend.Interfaces;
using ProductManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagementApp.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IStoreService _storeService;

        public ProductsController(IProductService productService, IStoreService storeService)
        {
            _productService = productService;
            _storeService = storeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            //return Ok(_productService.GetAllProducts());
            var model = _productService.GetAllProducts();
            return View("List", model);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult GetById(string id)
        {
            return Ok(_productService.GetProductById(id));
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            _productService.DeleteProduct(id);
            return NoContent();
        }

        [HttpGet]
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
        public IActionResult Add(ProductViewModel productModel)
        {
            var product = new Product
            {
                Name = productModel.Name,
                Amount = productModel.Amount,
                Price = productModel.Price,
                StoreId = productModel.StoreId
            };

            _productService.AddProduct(product);

            return Redirect("~/Home/Index");
        }

        [HttpPut]
        public IActionResult Update(Product product)
        {
            return Ok(_productService.UpdateProduct(product));
        }
    }
}
