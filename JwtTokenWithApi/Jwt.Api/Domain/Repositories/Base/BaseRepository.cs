using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jwt.Api.Domain.Repositories.Base
{
    public class BaseRepository
    {
        protected readonly ApiDbContext context;
        public BaseRepository(ApiDbContext context)
        {
            this.context = context;
        }
    }
}
