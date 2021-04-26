using ProductManagementApp.Backend.Data;
using System;
using System.Collections.Generic;

namespace ProductManagementApp.ViewModels
{
    public class PurchasesViewModel
    {
        public List<ProductViewModel> Products { get; set; }
        public string ProductId { get; set; }

        public List<Store> Stores { get; set; }
        public string StoreId { get; set; }
        public string StoreName { get; set; }

        public List<Supplier> Suppliers { get; set; }
        public string SupplierId { get; set; }
        public string SupplierName { get; set; }

        public string Id { get; set; }
        public DateTime Date { get; set; }
        public int TotalAmount  { get; set; }
        public double TotalPrice { get; set; }
    }
}
