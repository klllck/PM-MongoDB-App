using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ProductManagementApp.Backend.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagementApp.ViewModels
{
    public class ProductViewModel
    {

        public string Name { get; set; }

        public double Amount { get; set; }

        public double Price { get; set; }

        public List<Store> Stores { get; set; }

        public string StoreId { get; set; }
    }
}
