using Jwt.Api.Domain.Model;
using Jwt.Api.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jwt.Api.Domain.Services
{
    public interface IUserService
    {
        UserResponse AddUser(User user);
        UserResponse GetUserById(int id);
        UserResponse GetByEmailAndPassword(string email, string password);
        void SaveRefreshToken(int id, string refreshToken);
        UserResponse GetUserWithRefreshToken(string refreshToken);
        void RemoveRefreshToken(User user);
    }
}
