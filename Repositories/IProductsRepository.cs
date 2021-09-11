using csApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csApi.Repositories
{
    public interface IProductsRepository
    {
        IEnumerable<Product> Get();
        Product GetProduct(int id);
        void CreateProduct(Product product);
        void UpdateProduct(Product updatedProduct);
        void DeleteProduct(int id);
    }
}
