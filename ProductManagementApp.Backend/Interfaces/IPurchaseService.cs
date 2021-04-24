using ProductManagementApp.Backend.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManagementApp.Backend.Interfaces
{
    public interface IPurchaseService
    {
        List<Purchase> GetAllPurchases();
        Purchase GetPurchaseById(string id);
        Purchase AddPurchase(Purchase purchase);
        Purchase UpdatePurchase(Purchase purchase);
        void DeletePurchase(string id);
    }
}
