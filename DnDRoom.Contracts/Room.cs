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
        public string OwnerId { get; set; }
        public User Owner { get; set; }
        public string Name { get; set; }
        public List<Room_User> Players { get; set; }

        public Room()
        {
            Owner = new User();
            OwnerId = string.Empty;
            Name = string.Empty;
            Players = new List<Room_User>();
        }

        public Room(User owner, string name)
        {
            Owner = owner;
            OwnerId = owner.Id;
            Name = name;
            Players = new List<Room_User>();
        }
    }
}
