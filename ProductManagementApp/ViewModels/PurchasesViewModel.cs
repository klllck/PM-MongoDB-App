using ProductManagementApp.Backend.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagementApp.ViewModels
{
    public class PurchasesViewModel
    {
        public List<Product> Products { get; set; }
        public List<Product> ChosenProducts { get; set; }
        public string ProductId { get; set; }

        public List<Store> Stores { get; set; }
        public string StoreId { get; set; }

        public List<Supplier> Suppliers { get; set; }
        public string SupplierId { get; set; }

        public DateTime Date { get; set; }
        public int TotalAmount  { get; set; }
        public double TotalPrice { get; set; }
    }
}
