using Microsoft.AspNetCore.Mvc;
using ProductManagementApp.Backend.Data;
using ProductManagementApp.Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagementApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoresController : Controller
    {
        private readonly IStoreService _storeService;

        public StoresController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_storeService.GetAllStores());
        }

        [HttpGet("{id}", Name = "GetStore")]
        public IActionResult GetById(string id)
        {
            return Ok(_storeService.GetStoreById(id));
        }

        [HttpPost]
        public IActionResult Add(Store store)
        {
            return Ok(_storeService.AddStore(store));
        }
    }
}
