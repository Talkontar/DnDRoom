using DnDRoom.Contracts;
using DnDRoom.Data.interfaces;
using DnDRoom.Models.Requests;
using DnDRoom.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDRoom.Services.Realisations
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepo _characterRepo;

        public CharacterService(ICharacterRepo characterRepo)
        {
            _characterRepo = characterRepo;
        }

        public Task Create(CharacterCreateRequest chaacterCreateRequest, User user, Room room)
        {
            var newChar = new Character()
            {
                Name = chaacterCreateRequest.Name,
                OwnerId = user.Id,
                RoomId = room.Id
            };
            //todo refactor async methods
            return _characterRepo.Create(newChar);
        }
    }
}
