using ProductManagementApp.Backend.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagementApp.ViewModels
{
    public class SupplierViewModel
    {
        public List<Supplier> Suppliers { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
        public string SupplierId { get; set; }

        public string SupplierName { get; set; }
        public string SupplierDescription { get; set; }
        public string SupplierPhone { get; set; }
        public string SupplierEmail { get; set; }
    }
}
