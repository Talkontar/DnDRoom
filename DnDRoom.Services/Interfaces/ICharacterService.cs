using DnDRoom.Contracts;
using DnDRoom.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDRoom.Services.Interfaces
{
    public interface ICharacterService
    {
        Task Create(CharacterCreateRequest characterCreateRequest, User user, Room room);
    }
}
