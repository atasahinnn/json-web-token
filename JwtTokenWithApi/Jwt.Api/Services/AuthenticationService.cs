using Jwt.Api.Domain.Responses;
using Jwt.Api.Domain.Services;
using Jwt.Api.Security.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jwt.Api.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly IUserService userService;
        private readonly ITokenHandler tokenHandler;

        public AuthenticationService(IUserService userService, ITokenHandler tokenHandler)
        {
            this.userService = userService;
            this.tokenHandler = tokenHandler;
        }

        public AccessTokenResponse CreateAccessToken(string email, string password)
        {
            UserResponse response = userService.GetByEmailAndPassword(email, password);

            if (response.Success)
            {
                AccessToken accessToken = tokenHandler.CreateAccessToken(response.User);
                userService.SaveRefreshToken(response.User.UserId, accessToken.RefreshToken);

                return new AccessTokenResponse(accessToken);
            }

            else
            {
                return new AccessTokenResponse(response.Message);
            }
        }

        public AccessTokenResponse CreateAccessTokenByRefreshToken(string refreshToken)
        {
            UserResponse response = userService.GetUserWithRefreshToken(refreshToken);

            if (response.Success)
            {
                if (response.User.RefreshTokenEndDate > DateTime.Now)
                {
                    AccessToken accessToken = tokenHandler.CreateAccessToken(response.User);
                    userService.SaveRefreshToken(response.User.UserId, accessToken.RefreshToken);

                    return new AccessTokenResponse(accessToken);
                }

                else
                {
                    return new AccessTokenResponse("RefreshToken Süresi Dolmuştur.");
                }
            }

            else
            {
                return new AccessTokenResponse("RefreshToken Bulunamadı.");
            }
        }

        public AccessTokenResponse RevokeRefreshToken(string refreshToken)
        {
            UserResponse response = userService.GetUserWithRefreshToken(refreshToken);

            if (response.Success)
            {
                userService.RemoveRefreshToken(response.User);
    
                return new AccessTokenResponse(new AccessToken());
            }
            else
            {
                return new AccessTokenResponse("RefreshToken Bulunamadı.");
            }
        }
    }
}
