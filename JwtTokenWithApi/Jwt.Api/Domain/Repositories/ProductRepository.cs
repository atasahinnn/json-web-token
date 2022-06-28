using Jwt.Api.Domain.Model;
using Jwt.Api.Domain.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jwt.Api.Domain.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(ApiDbContext context) : base(context)
        {

        }

        public async Task AddProductAsync(Product product)
        {
            await context.Products.AddAsync(product);
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await context.Products.ToListAsync();
        }

        public async Task RemoveProductAsync(int productId)
        {
            var product = await GetByIdAsync(productId);
            context.Products.Remove(product);            
        }

        public void UpdateProduct(Product product)
        {
            context.Products.Update(product);
        }

    }
}
