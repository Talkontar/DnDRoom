using DnDRoom.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDRoom.Data
{
    public class CharacterRepo : ICharacterRepo
    {
        private readonly ApplicationDbContext _context;

        public CharacterRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create (Character character)
        {
            await _context.AddAsync<Character>(character);
            await _context.SaveChangesAsync();
        }
    }
}
