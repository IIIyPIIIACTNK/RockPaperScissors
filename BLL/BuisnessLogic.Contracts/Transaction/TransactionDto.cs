using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace BuisnessLogic.Contracts.Transaction
{
    public class TransactionDto
    {
        public string Id { get; set; }
        public DataAccess.Entities.User Sender { get; set; }
        public DataAccess.Entities.User Recivier { get; set; }
        public decimal Ammount { get; set; }
        public DateTime TimeOfTransation { get; set; }
    }
}
