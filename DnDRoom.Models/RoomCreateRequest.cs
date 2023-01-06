using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDRoom.Models
{
    public class RoomCreateRequest
    {
        public string roomName { get; set; }

        public RoomCreateRequest(string roomName)
        {
            this.roomName = roomName;
        }
    }
}
