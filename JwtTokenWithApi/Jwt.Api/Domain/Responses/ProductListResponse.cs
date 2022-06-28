using Jwt.Api.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jwt.Api.Domain.Responses
{
    public class ProductListResponse : BaseResponse
    {
        public ProductListResponse(bool success, string message, IEnumerable<Product> ProductList) : base(success, message)
        {
            this.ProductList = ProductList;
        }

        // SUCCESS
        public ProductListResponse(IEnumerable<Product> ProductList) : this(true, string.Empty, ProductList)
        {

        }

        // WARNING

        public ProductListResponse(string message) : this(false, message, null)
        {

        }

        public IEnumerable <Product> ProductList { get; set; }
    }
}
