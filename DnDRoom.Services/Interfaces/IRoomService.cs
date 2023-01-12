using DnDRoom.Contracts;
using DnDRoom.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDRoom.Services.Interfaces
{
    public interface IRoomService
    {
        Task<Room> Create(RoomCreateRequest roomCreateRequest, string ownerId);
        Task Delete(int id);
        Task<Room?> GetById(int id);
        Task AddPlayer(int roomId, string playerId);
        Task CreatePlayerCharacter(CharacterCreateRequest characterCreateRequest, string ownerId, int roomId);
    }
}
