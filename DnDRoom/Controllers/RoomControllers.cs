using DnDRoom.Contracts;
using DnDRoom.Models;
using DnDRoom.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DnDRoom.Controllers
{
    [ApiController]
    [Route("api/rooms")]
    public class RoomControllers : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomControllers(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] RoomCreateRequest roomCreateRequest)
        {
            var newRoom = await _roomService.create(roomCreateRequest, User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? ""); 
            return Ok("");
        }
    }
}
