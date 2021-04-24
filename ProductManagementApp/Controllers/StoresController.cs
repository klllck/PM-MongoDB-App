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
        private readonly IPurchaseService _purchaseService;
        private readonly ISupplierService _supplierService;

        public StoresController(IStoreService storeService, IProductService productService, IPurchaseService purchaseService, ISupplierService supplierService)
        {
            _storeService = storeService;
            _productService = productService;
            _purchaseService = purchaseService;
            _supplierService = supplierService;
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

        [HttpGet("/store/purchase-create")]
        public IActionResult CreatePurchase(StoreViewModel storeViewModel)
        {
            var products = _productService.GetAllProducts();
            var storeId = storeViewModel.StoreId;

            var model = new PurchasesViewModel
            {
                Products = products,
                StoreId = storeId,
            };

            return View(model);
        }
    }
}
