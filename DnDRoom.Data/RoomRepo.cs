using DnDRoom.Contracts;
using Microsoft.EntityFrameworkCore;
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
            await _context.AddAsync(room); 
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
            room.Players.Add(newPlayer);
            await _context.SaveChangesAsync();
        }

        public List<User> GetPlayers(Room room)
        {
            return _context.Rooms.Include(x => x.Players).Single(x => x == room).Players.ToList();
        }

        public List<Character> GetPlayerCharacters(Room room)
        {
            return _context.Rooms.Include(x => x.PlayerCharacters).Single(x => x == room).PlayerCharacters.ToList();
        }
    }
}
