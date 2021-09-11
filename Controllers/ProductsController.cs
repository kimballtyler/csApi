using csApi.Models;
using csApi.Repositories;
using csApi.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csApi.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository repository;

        public ProductsController(IProductsRepository repository)
        { 
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var products = repository.Get();
            return products;
        }

        [HttpGet("{id}")]
        public Product GetProduct(int id)
        {
            var product = repository.GetProduct(id);
            return product;
        }

        [HttpPost]
        public ActionResult<ProductDto> CreateProduct(CreateProductDto productDto)
        {
            Product product = new()
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Price = productDto.Price,
                Description = productDto.Description
            };

            repository.CreateProduct(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product.AsDto());
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, CreateProductDto productDto)
        {
            var existingProduct = repository.GetProduct(id);
            Product updatedProduct = new()
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Price = productDto.Price,
                Description = productDto.Description
            };

            repository.UpdateProduct(updatedProduct);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var existingProduct = repository.GetProduct(id);
            repository.DeleteProduct(id);
            return NoContent();
        }
    }
}
