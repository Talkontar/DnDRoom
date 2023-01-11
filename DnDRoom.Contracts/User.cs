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
        [NotMapped]
        public List<Room_User> ConnectedRooms { get; set; }

    }
}
