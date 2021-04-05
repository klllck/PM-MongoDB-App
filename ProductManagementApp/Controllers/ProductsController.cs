using Microsoft.AspNetCore.Mvc;
using ProductManagementApp.Backend.Data;
using ProductManagementApp.Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagementApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
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

        [HttpPost]
        public IActionResult Add(Product product)
        {
            return Ok(_productService.AddProduct(product));
        }

        [HttpPut]
        public IActionResult Update(Product product)
        {
            return Ok(_productService.UpdateProduct(product));
        }
    }
}
