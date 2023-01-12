using DnDRoom.Models.Responses;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDRoom.Services.Interfaces
{
    public interface IJwtService
    {
        public LoginResponse CreateToken(IdentityUser user);
    }
}
