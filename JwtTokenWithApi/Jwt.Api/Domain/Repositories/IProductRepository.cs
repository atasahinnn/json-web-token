using Jwt.Api.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jwt.Api.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListAsync();
        Task AddProductAsync(Product product);
        Task RemoveProductAsync(int productId);
        void UpdateProduct(Product product);
        Task<Product> GetByIdAsync(int id);
    }
}
