using AutoMapper;
using Jwt.Api.Domain.Model;
using Jwt.Api.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jwt.Api.Mapping
{
    public class UserMapping:Profile
    {
        public UserMapping()
        {
            CreateMap<UserResource, User>();
            CreateMap<User, UserResource>();
        }
    }
}
