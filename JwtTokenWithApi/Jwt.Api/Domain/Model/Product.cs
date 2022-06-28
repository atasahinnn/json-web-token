using System;
using System.Collections.Generic;

#nullable disable

namespace Jwt.Api.Domain.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string CategoryId { get; set; }
        public decimal Price { get; set; }
    }
}
