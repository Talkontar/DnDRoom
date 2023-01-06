using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDRoom.Contracts
{
    public class User : IdentityUser
    {
        public ICollection<Room> Rooms { get; set; }
    }
}
