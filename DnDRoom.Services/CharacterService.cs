using DnDRoom.Contracts;
using DnDRoom.Data;
using DnDRoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDRoom.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepo _characterRepo;

        public CharacterService(ICharacterRepo characterRepo)
        {
            _characterRepo = characterRepo;
        }

        public async Task Create (CharacterCreateRequest chaacterCreateRequest, User user, Room room)
        {
            var newChar = new Character()
            {
                Name = chaacterCreateRequest.Name,
                Owner = user,
                OwnerId = user.Id,
                Room = room,
                RoomId = room.Id
            };
            await _characterRepo.Create(newChar);
        }
    }
}
