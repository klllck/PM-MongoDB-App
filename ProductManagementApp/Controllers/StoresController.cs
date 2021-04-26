using Microsoft.AspNetCore.Mvc;
using ProductManagementApp.Backend.Data;
using ProductManagementApp.Backend.Interfaces;
using ProductManagementApp.ViewModels;

namespace ProductManagementApp.Controllers
{
    public class StoresController : Controller
    {
        private readonly IStoreService _storeService;
        private readonly IProductService _productService;
        public StoresController(IStoreService storeService, IProductService productService)
        {
            _storeService = storeService;
            _productService = productService;
        }

        [HttpGet("/stores")]
        public IActionResult GetAll()
        {
            var model = _storeService.GetAllStores();
            return View("List", model);
        }

        [HttpGet("stores/details/{id}")]
        public IActionResult Detail(string id)
        {
            var store =_storeService.GetStoreById(id);

            var products = _productService.GetAllProducts().FindAll(p => p.StoreId == store.Id);

            var model = new StoreViewModel
            {
                Name = store.Name,
                Address = store.Address,
                Phone = store.Phone,
                PostalCode = store.PostalCode,
                Products = products
            };

            return View(model);
        }


        [HttpPost("stores/add")]
        public IActionResult Add(Store store)
        {
            return Ok(_storeService.AddStore(store));
        }
    }
}
