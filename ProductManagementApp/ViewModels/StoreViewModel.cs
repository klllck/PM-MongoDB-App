using ProductManagementApp.Backend.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagementApp.ViewModels
{
    public class StoreViewModel
    {
        public string StoreId { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string PostalCode { get; set; }


        public List<Product> Products { get; set; }
    }
}
