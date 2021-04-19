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
    }
}
