using Jwt.Api.Domain.Responses;
using Jwt.Api.Domain.Services;
using Jwt.Api.Extensions;
using Jwt.Api.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jwt.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;
        public LoginController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost]
        public IActionResult AccessToken(LoginResource loginResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            else
            {
                AccessTokenResponse tokenResponse = authenticationService.CreateAccessToken(loginResource.Email, loginResource.Password);

                if (tokenResponse.Success)
                {
                    return Ok(tokenResponse.accessToken);
                }

                else
                {
                    return BadRequest(tokenResponse.Message);
                }
            }
        }

        [HttpPost]
        public IActionResult RefreshToken(TokenResource tokenResource)
        {
            AccessTokenResponse tokenResponse = authenticationService.CreateAccessTokenByRefreshToken(tokenResource.RefreshToken);

            if (tokenResponse.Success)
            {
                return Ok(tokenResponse.accessToken);
            }

            else
            {
                return BadRequest(tokenResponse.Message);
            }
        }

        [HttpPost]
        public IActionResult RemoveRefreshToken(TokenResource tokenResource)
        {
            AccessTokenResponse tokenResponse = authenticationService.RevokeRefreshToken(tokenResource.RefreshToken);

            if (tokenResponse.Success)
            {
                return Ok(tokenResponse.accessToken);
            }
            else
            {
                return BadRequest(tokenResponse.Message);
            }
        }
    }
}
