using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDRoom.Contracts
{
    public class User : IdentityUser
    {
        public List<Room> CreatedRooms { get; set; }
        public List<Room> ConnectedRooms { get; set; }
        public List<Character> CreatedCharacters { get; set; }
    }
}
