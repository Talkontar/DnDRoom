using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDRoom.Contracts
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OwnerId { get; set; }
        public User Owner { get; set; }
        public List<User> Players { get; set; }
        public List<Character> PlayerCharacters { get; set; }
    }
}
