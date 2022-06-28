using Jwt.Api.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jwt.Api.Domain.Responses
{
    public class UserResponse:BaseResponse
    {
        public User User { get; set; }

        private UserResponse(bool success, string message, User user) : base(success,message)
        {
            this.User = user;
        }

        // SUCCESS

        public UserResponse(User user) : this(true, string.Empty, user) { }

        // WARNING 

        public UserResponse(string message):this(false,message,null)
        {

        }


    }
}
