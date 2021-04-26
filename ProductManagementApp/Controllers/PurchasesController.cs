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
        private readonly ISupplierService _supplierService;

        public PurchasesController(IPurchaseService purchaseService, IStoreService storeService, IProductService productService, ISupplierService supplierService)
        {
            _purchaseService = purchaseService;
            _productService = productService;
            _storeService = storeService;
            _supplierService = supplierService;
        }

        [HttpGet("/purchases")]
        public IActionResult GetAll()
        {
            var purchases = _purchaseService.GetAllPurchases();

            var model = purchases.Select(p => new PurchasesViewModel
            {
                Id = p.Id,
                Date = p.Date,
                TotalAmount = p.TotalAmount,
                TotalPrice = Math.Round(p.TotalPrice, 2),
                StoreId = p.StoreId,
                StoreName =  _storeService.GetStoreById(p.StoreId).Name,
                SupplierId = p.SupplierId,
                SupplierName = _supplierService.GetSupplierById(p.SupplierId).Name
            });

            return View("List", model);
        }

        [HttpGet("/purchases/create")]
        public IActionResult Create()
        {
            var stores = _storeService.GetAllStores();
            var suppliers = _supplierService.GetAllSuppliers();

            var model = new PurchasesViewModel
            {
                Stores = stores,
                Suppliers = suppliers
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(PurchasesViewModel purchasesViewModel)
        {
            var supplierId = purchasesViewModel.SupplierId;
            var products = _productService.GetAllProducts().FindAll(p => p.SupplierId == supplierId);

            var productsModel = products.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
            }).ToList();

            purchasesViewModel.Products = productsModel;
            purchasesViewModel.Stores = _storeService.GetAllStores();
            purchasesViewModel.Suppliers = _supplierService.GetAllSuppliers();

            return View(purchasesViewModel);
        }

        [HttpPost]
        public IActionResult Add(PurchasesViewModel purchasesViewModel, List<string> choosenProducts)
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
                Date = DateTime.UtcNow,
                TotalAmount = products.Count,
                TotalPrice = products.Sum(p => p.Price),
                StoreId = purchasesViewModel.StoreId,
                SupplierId = purchasesViewModel.SupplierId,
            };

            _purchaseService.AddPurchase(purchase);

            return Redirect("~/purchases");
        }


        [HttpGet("/purchases/delete/{id}")]
        public IActionResult Delete(string id)
        {
            _purchaseService.DeletePurchase(id);
            return Redirect("/purchases");
        }
    }
}
