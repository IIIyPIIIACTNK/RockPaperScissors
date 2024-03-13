using DataAccess.Context;
using DataAccess.Entities;
using DataAccess.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementations
{
    public class MatchHistoryRepository : Repository<MatchHistory, string>, IMatchHistoryRepository
    {
        public MatchHistoryRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
