using DataAccess.Context;
using DataAccess.Entities;
using DataAccess.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementations
{
    public class UserRepository : Repository<User, string>, IUserRepository
    {
        DatabaseContext dbContext;
        public UserRepository(DatabaseContext context) : base(context)
        {
            dbContext = context;
        }

        public async Task<User> GetByName(string name)
        {
            return await dbContext.Users.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
