using Microsoft.AspNetCore.Mvc;
using ProductManagementApp.Backend.Data;
using ProductManagementApp.Backend.Interfaces;
using ProductManagementApp.ViewModels;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ProductManagementApp.Controllers
{
    public class PurchasesController : Controller
    {
        private readonly IPurchaseService _purchaseService;
        private readonly IStoreService _storeService;
        private readonly IProductService _productService;

        public PurchasesController(IPurchaseService purchaseService, IStoreService storeService, IProductService productService)
        {
            _purchaseService = purchaseService;
            _productService = productService;
            _storeService = storeService;
        }

        [HttpGet("/purchases")]
        public IActionResult GetAll()
        {
            var model = _purchaseService.GetAllPurchases();
            return View("List", model);
        }

        [HttpGet("/purchases/create")]
        public IActionResult Create()
        {
            var stores = _storeService.GetAllStores();
            var products = _productService.GetAllProducts();

            var model = new PurchasesViewModel
            {
                Products = products,
                Stores = stores
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(PurchasesViewModel purchasesViewModel, List<string> choosenProducts)
        {
            var products = new List<Product>();

            foreach (var id in choosenProducts)
            {
                var product = _productService.GetProductById(id);
              
                if (!products.Contains(product))
                {
                    products.Add(product);
                }
            }

            var purchase = new Purchase
            {
                StoreId = purchasesViewModel.StoreId,
                Date = DateTime.UtcNow,
                TotalAmount = products.Sum(p => p.Amount),
                TotalPrice = products.Sum(p => p.Price)
            };

            _purchaseService.AddPurchase(purchase);

            return Redirect("~/purchases");
        }
    }
}
