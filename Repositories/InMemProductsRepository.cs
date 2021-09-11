using csApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csApi.Repositories
{
    public class InMemProductsRepository : IProductsRepository
    {
        private List<Product> products = new()
        {
            new Product { Id = 1, Name = "Snare", Price = 624.95, Description = "A Mapex birch marching snare drum" },
            new Product { Id = 2, Name = "Tenors", Price = 929.95, Description = "A Mapex set of marching tenor drums" },
            new Product { Id = 3, Name = "Bass", Price = 479.95, Description = "A Mapex maple marching bass drum" }
        };

        public IEnumerable<Product> Get()
        {
            return products;
        }

        public Product GetProduct(int id)
        {
            return products.Where(product => product.Id == id).SingleOrDefault();
        }

        public void CreateProduct(Product product)
        {
            products.Add(product);
        }

        public void UpdateProduct(Product updatedProduct)
        {
            var index = products.FindIndex(existingProduct => existingProduct.Id == updatedProduct.Id);
            products[index] = updatedProduct;
        }

        public void DeleteProduct(int id)
        {
            var index = products.FindIndex(existingProduct => existingProduct.Id == id);
            products.RemoveAt(index);
        }
    }
}
