using BuisnessLogic.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Contracts.Match
{
    public class MatchDto
    {
        public string Id { get; set; }
        public DataAccess.Entities.User Player1 { get; set; }
        public DataAccess.Entities.User Player2 { get; set; }
        public decimal Bid { get; set; }  

    }
}
