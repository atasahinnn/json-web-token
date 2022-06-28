using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jwt.Api.Domain;
using Jwt.Api.Domain.Model;
using Jwt.Api.Resources;

namespace Jwt.Api.Mapping
{
    public class ProductMapping:Profile
    {
        public ProductMapping()
        {
            CreateMap<ProductResource, Product>();
            CreateMap<Product, ProductResource>();
        }
    }
}
