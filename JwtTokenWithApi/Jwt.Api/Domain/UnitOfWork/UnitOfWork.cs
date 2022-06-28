using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jwt.Api.Domain.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApiDbContext context;
        public UnitOfWork(ApiDbContext context)
        {
            this.context = context;
        }

        public void Complete()
        {
            this.context.SaveChanges();
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
