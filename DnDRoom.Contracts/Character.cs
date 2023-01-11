using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDRoom.Contracts
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User Owner { get; set; }
        public string OwnerId { get; set; }
        public Room Room { get; set; }
        public int RoomId { get; set; }
    }
}
