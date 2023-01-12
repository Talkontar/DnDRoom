using DnDRoom.Contracts;
using DnDRoom.Data.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDRoom.Data.Realisations
{
    public class CharacterRepo : ICharacterRepo
    {
        private readonly ApplicationDbContext _context;

        public CharacterRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Character character)
        {
            throw new Exception();
            //todo change addAsync to add
            await _context.AddAsync(character);
            await _context.SaveChangesAsync();
        }
    }
}
