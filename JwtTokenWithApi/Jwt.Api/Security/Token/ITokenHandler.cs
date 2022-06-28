using Jwt.Api.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jwt.Api.Security.Token
{
    public interface ITokenHandler
    {
        AccessToken CreateAccessToken(User user);
        void RevokeRefreshToken(User user);
    }
}
