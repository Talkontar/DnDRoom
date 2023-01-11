using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDRoom.Contracts
{
    public class Room_User
    {
        //public int Id { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
