using DnDRoom.Contracts;
using DnDRoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDRoom.Services
{
    public interface ICharacterService
    {
        Task Create(CharacterCreateRequest characterCreateRequest, User user, Room room);
    }
}
