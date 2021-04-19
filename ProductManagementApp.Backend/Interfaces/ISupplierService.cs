using ProductManagementApp.Backend.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManagementApp.Backend.Interfaces
{
    public interface ISupplierService
    {
        List<Supplier> GetAllSuppliers();
        Supplier GetSupplierById(string id);
        Supplier AddSupplier(Supplier supplier);
        Supplier UpdateSupplier(Supplier supplier);
        void DeleteSupplier(string supplierId);
    }
}
