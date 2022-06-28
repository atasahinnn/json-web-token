using Jwt.Api.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jwt.Api.Domain.Responses
{
    public class ProductResponse:BaseResponse
    {
        public ProductResponse(bool success, string message, Product product): base(success,message)
        {
            this.Product = product;
        }

        // SUCCESS

        public ProductResponse(Product product):this(true, string.Empty, product)
        {

        }

        // WARNING

        public ProductResponse(string message):this(false, message, null )
        {

        }

        public Product Product { get; set; }
    }
}
