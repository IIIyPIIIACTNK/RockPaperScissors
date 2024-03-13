using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Contracts.User
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
    }
}
