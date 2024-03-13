using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Match : IEntity<string>
    {
        public string Id { get; set; }
        public User Player1 { get; set; }
        public User Player2 { get; set; }
    }
}
