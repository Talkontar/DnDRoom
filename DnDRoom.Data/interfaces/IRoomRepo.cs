using DnDRoom.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDRoom.Data.interfaces
{
    public interface IRoomRepo
    {
        Task Create(Room room);
        Task<Room?> GetById(int id);
        Task Delete(Room room);
        Task AddPlayer(Room room, User newPlayer);
        List<User> GetPlayers(Room room);
        List<Character> GetPlayerCharacters(Room room);
    }
}
