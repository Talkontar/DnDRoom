using DnDRoom.Contracts;
using DnDRoom.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDRoom.Services
{
    public interface IRoomService
    {
        public Task<Room> create(RoomCreateRequest roomCreateRequest, string ownerId);
    }
}
