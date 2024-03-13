using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Contracts.GameTransactions
{
    public class GameTransactionsDto
    {
        public string Id { get; set; }
        public List<DataAccess.Entities.Transaction> Transactions { get; set; }
        public DataAccess.Entities.Match Match { get; set; }
    }
}
