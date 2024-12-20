using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entities;
using Talabat.Core.Repositories.Contract;

namespace SimpleTalabat.Controllers
{

    public class ProductController : BaseAPIController
    {
        private readonly IGenericRepository<Product> _productRepo;

        public ProductController(IGenericRepository<Product> ProductRepo) //Ask CLR To Get Object of IGenericRepository
        {
            _productRepo = ProductRepo;
        }

        [HttpGet] //https://localhost:7294/api/Product

        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts() {
            var Products = await _productRepo.GetAllAsync();
            return Ok(Products);
        }

        [HttpGet("{ID}")] //https://localhost:7294/api/Product/ID
        public async Task<ActionResult<Product>> GetByID(int ID) {
            var Product = await _productRepo.GetByIdAsync(ID);
            if (Product == null)
            {
                return NotFound();  
            }
            return Ok(Product); 
        }

    }
}
