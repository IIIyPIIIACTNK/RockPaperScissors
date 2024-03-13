using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class GameTransactions : IEntity<string>
    {
        public string Id { get; set; }
        public List<Transactions> Transactions { get; set; }
        public Match Match { get; set; }
    }
}
