using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Contracts.MatchHistory
{
    public class MatchHistoryDto
    {
        public string Id { get; set; }
        public DataAccess.Entities.User Winner { get; set; }
        public DataAccess.Entities.User Losser { get; set; }
        public DataAccess.Entities.GameTransactions Transactions { get; set; }
    }
}
