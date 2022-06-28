using Jwt.Api.Domain.Model;
using Jwt.Api.Domain.Repositories.Base;
using Jwt.Api.Security.Token;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jwt.Api.Domain.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly TokenOptions tokenOptions;
        public UserRepository(ApiDbContext context, IOptions<TokenOptions> tokenOptions):base(context)
        {
            this.tokenOptions = tokenOptions.Value;
        }

        public void AddUser(User user)
        {
            context.Users.Add(user);
        }

        public User GetByEmailAndPassword(string email, string password)
        {
            return context.Users.Where(u => u.Email == email && u.Password == password).FirstOrDefault();
        }

        public User GetUserById(int id)
        {
            return context.Users.Find(id);
        }

        public User GetUserWithRefreshToken(string refreshToken)
        {
            return context.Users.FirstOrDefault(u => u.RefreshToken == refreshToken);
        }

        public void RemoveRefreshToken(User user)
        {
            User activeUser = context.Users.Find(user.UserId);
            activeUser.RefreshToken = null;
            activeUser.RefreshTokenEndDate = null;
        }

        public void SaveRefreshToken(int userId, string refreshToken)
        {
            User activeUser = this.GetUserById(userId);
            activeUser.RefreshToken = refreshToken;
            activeUser.RefreshTokenEndDate = DateTime.Now.AddMinutes(tokenOptions.RefreshTokenExpiration);

        }
    }
}
