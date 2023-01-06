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

        public async Task Add(Room room)
        {
            _context.Add(room); 
            await _context.SaveChangesAsync();
        }
    }
}
