using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class MatchHistory : IEntity<string>
    {
        public string Id { get; set; }
        public User Winner { get; set; }
        public User Losser {  get; set; }
        public GameTransactions Transactions { get; set; }
    }
}
