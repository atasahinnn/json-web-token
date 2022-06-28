using Jwt.Api.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jwt.Api.Domain.Repositories
{
    public interface IUserRepository
    {
        void AddUser(User user);
        User GetUserById(int id);
        User GetByEmailAndPassword(string email, string password);
        void SaveRefreshToken(int userId, string refreshToken);
        User GetUserWithRefreshToken(string refreshToken);
        void RemoveRefreshToken(User user); 

    }
}
