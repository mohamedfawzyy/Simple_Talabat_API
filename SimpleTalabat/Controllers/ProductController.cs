using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleTalabat.DTOS;
using Talabat.Core.Entities;
using Talabat.Core.Repositories.Contract;
using Talabat.Core.Specification;

namespace SimpleTalabat.Controllers
{

    public class ProductController : BaseAPIController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IMapper mapper;

        public ProductController(IGenericRepository<Product> ProductRepo, IMapper mapper) //Ask CLR To Get Object of IGenericRepository
        {
            _productRepo = ProductRepo;
            this.mapper = mapper;
        }

        [HttpGet] //https://localhost:7294/api/Product

        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts() {
            var specs = new ProuctSpecification();
            var Products = await _productRepo.GetAllWithSpecsAsync(specs);
            return Ok(mapper.Map<IEnumerable<Product>,IEnumerable<ProductDto>>(Products));
        }

        [HttpGet("{ID}")] //https://localhost:7294/api/Product/ID
        public async Task<ActionResult<ProductDto>> GetByID(int ID) {
            var specs = new ProuctSpecification(ID);
            var Product = await _productRepo.GetByIdWithSpecsAsync(specs);
            if (Product == null)
            {
                return NotFound();  
            }
            return Ok(mapper.Map<Product,ProductDto>(Product)); 
        }

    }
}
