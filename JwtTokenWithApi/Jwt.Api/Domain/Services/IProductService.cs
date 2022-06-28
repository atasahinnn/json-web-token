using Jwt.Api.Domain.Model;
using Jwt.Api.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jwt.Api.Domain.Services
{
    public interface IProductService
    {
        Task<ProductListResponse> ListAsync();
        Task<ProductResponse> AddProduct(Product product);
        Task<ProductResponse> RemoveProduct(int productId);
        Task<ProductResponse> UpdateProduct(Product product, int productId);
        Task<ProductResponse> GetByIdAsync(int productId);
    }
}
