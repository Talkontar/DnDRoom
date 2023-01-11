using DnDRoom.Contracts;
using DnDRoom.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDRoom.Services
{
    public interface IUserService
    {
        public Task<IActionResult> Create(RegisterModel registerModel);
        public Task<IActionResult> Login(LoginRequest loginRequest);
        public Task<User> GetById(string id);
        public Task<IEnumerable<Room>> GetCreatedRooms(string id);
    }
}
