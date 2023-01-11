using DnDRoom.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDRoom.Data
{
    public class RoomRepo : IRoomRepo
    {
        private readonly ApplicationDbContext _context;

        public RoomRepo (ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Room room)
        {
            _context.Add(room); 
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Room room)
        {
            _context.Remove(room);
            await _context.SaveChangesAsync();
        }

        public async Task<Room?> GetById(int id)
        {
            return await _context.FindAsync<Room>(id);
        }

        public async Task AddPlayer(Room room, User newPlayer)
        {
            room.Players.Add(new Room_User()
            {
                Room = room,
                RoomId = room.Id,

                User = newPlayer,
                UserId = newPlayer.Id
            });
            await _context.SaveChangesAsync();
        }

        public List<User> GetPlayers(Room room)
        {
            return room.Players.Select(x => x.User).ToList();
        }
    }
}
