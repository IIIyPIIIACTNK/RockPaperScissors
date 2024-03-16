using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstractions
{
    public interface IUserRepository : IRepository<User,string>
    {
        public Task<User> GetByName(string name);
    }
}
