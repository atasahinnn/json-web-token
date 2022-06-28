using Jwt.Api.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jwt.Api.Domain.Responses;
using Jwt.Api.Resources;
using Jwt.Api.Domain;
using Jwt.Api.Domain.Model;
using Microsoft.AspNetCore.Authorization;

namespace Jwt.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            ProductListResponse productListResponse = await productService.ListAsync();

            if (productListResponse.Success)
            {
                return Ok(productListResponse.ProductList);
            }
            else
            {
                return BadRequest(productListResponse.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            ProductResponse productResponse = await productService.GetByIdAsync(id);

            if (productResponse.Success)
            {
                return Ok(productResponse.Product);
            }
            else
            {
                return BadRequest(productResponse.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductResource productResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                Product product = mapper.Map<ProductResource, Product>(productResource);
                var productResponse = await productService.AddProduct(product);

                if (productResponse.Success)
                {
                    return Ok(productResponse.Product);
                }
                else
                {
                    return BadRequest(productResponse.Message);
                }
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct(ProductResource productResource, int id)
        {
            Product product = mapper.Map<ProductResource, Product>(productResource);
            var response = await productService.UpdateProduct(product, id);

            if (response.Success)
            {
                return Ok(response.Product);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            ProductResponse response = await productService.RemoveProduct(id);

            if (response.Success)
            {
                return Ok();
            }
            else
            {
                return BadRequest(response.Message);
            }
        }
    }
}
