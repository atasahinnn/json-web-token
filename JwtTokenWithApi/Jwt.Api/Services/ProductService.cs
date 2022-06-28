using Jwt.Api.Domain.Model;
using Jwt.Api.Domain.Repositories;
using Jwt.Api.Domain.Responses;
using Jwt.Api.Domain.Services;
using Jwt.Api.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jwt.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IUnitOfWork unitOfWork;
        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ProductResponse> AddProduct(Product product)
        {
            try
            {
                await productRepository.AddProductAsync(product);
                await unitOfWork.CompleteAsync();
                return new ProductResponse(product);
            }
            catch (Exception ex)
            {

                return new ProductResponse($"Hata Kodu: {ex.Message}");
            }
        }

        public async Task<ProductResponse> GetByIdAsync(int productId)
        {
            try
            {
                Product product = await productRepository.GetByIdAsync(productId);

                if (product == null)
                {
                    return new ProductResponse("Ürün Bulunamadı.");
                }

                return new ProductResponse(product);
            }
            catch (Exception ex)
            {

                return new ProductResponse($"Hata Kodu: {ex.Message}");
            }       
        }

        public async Task<ProductListResponse> ListAsync()
        {
            try
            {
                IEnumerable<Product> products = await productRepository.ListAsync();

                if (products == null)
                {
                    return new ProductListResponse("Ürün Bulunamadı.");
                }

                return new ProductListResponse(products);
            }
            catch (Exception ex)
            {

                return new ProductListResponse($"Hata Kodu: {ex.Message}");
            }
        }

        public async Task<ProductResponse> RemoveProduct(int productId)
        {
            try
            {
                Product product = await productRepository.GetByIdAsync(productId);

                if (product == null)
                {
                    return new ProductResponse("Ürün Bulunamadı.");
                }

                else
                {
                    await productRepository.RemoveProductAsync(productId);
                    await unitOfWork.CompleteAsync();

                    return new ProductResponse(product);
                }

            }
            catch (Exception ex)
            {

                return new ProductResponse($"Hata Kodu: {ex.Message}");
            }
        }

        public async Task<ProductResponse> UpdateProduct(Product product, int productId)
        {
            try
            {
                var firstProduct = await productRepository.GetByIdAsync(productId);

                if (firstProduct == null)
                {
                    return new ProductResponse("Ürün Bulunamadı");
                }
                else
                {
                    firstProduct.Name = product.Name;
                    firstProduct.CategoryId = product.CategoryId;
                    firstProduct.Price = product.Price;

                    productRepository.UpdateProduct(firstProduct);
                    await unitOfWork.CompleteAsync();

                    return new ProductResponse(firstProduct);
                }
            }
            catch (Exception ex)
            {

                return new ProductResponse($"Hata Kodu: {ex.Message}");
            }       
        }
    }
}
