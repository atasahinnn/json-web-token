using AutoMapper;
using Jwt.Api.Domain.Model;
using Jwt.Api.Domain.Responses;
using Jwt.Api.Domain.Services;
using Jwt.Api.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Jwt.Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetUser()
        {
            IEnumerable<Claim> claims = User.Claims;

            string userId = claims.Where(c => c.Type == ClaimTypes.NameIdentifier).First().Value;

            UserResponse response = userService.GetUserById(int.Parse(userId));

            if (response.Success)
            {
                return Ok(response.User);
            }

            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpPost]
        public IActionResult AddUser(UserResource userResource)
        {
            User user = mapper.Map<UserResource, User>(userResource);
            UserResponse response = userService.AddUser(user);

            if (response.Success)
            {
                return Ok(response.User);
            }

            else
            {
                return BadRequest(response.Message);
            }
        }      
    }
}
