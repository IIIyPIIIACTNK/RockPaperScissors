using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Transactions : IEntity<string>
    {
        public string Id { get; set; }
        public User Sender { get; set; }
        public User Recivier { get; set; }
        public decimal Ammount { get; set; }
        public DateTime TimeOfTransation { get; set; }
    }
}
