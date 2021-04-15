using ProductManagementApp.Backend.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManagementApp.Backend.Interfaces
{
    public interface IStoreService
    {
        List<Store> GetAllStores();
        Store GetStoreById(string id);
        Store AddStore(Store store);
        Store UpdateStore(Store store);
        void DeleteStore(string store);
    }
}
