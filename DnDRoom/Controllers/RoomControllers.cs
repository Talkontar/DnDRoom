using AutoMapper;
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
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public RoomControllers(IRoomService roomService,
            IUserService userService,
            IMapper mapper)
        {
            _roomService = roomService;
            _userService = userService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] RoomCreateRequest roomCreateRequest)
        {
            var newRoom = await _roomService.Create(roomCreateRequest, User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "");
            return Ok("");
        }

        [Authorize]
        [HttpGet("getallcreated")]
        public async Task<IActionResult> GetAllCreated()
        {
            var rooms = await _userService.GetCreatedRooms(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "");
            var roomVMs = _mapper.Map<IEnumerable<RoomViewModel>>(rooms);
            return Ok(roomVMs);
        }

        [Authorize]
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            await _roomService.Delete(id);
            return NoContent();
        }

        [Authorize]
        [HttpPatch("{roomId}/connect")]
        public async Task<IActionResult> Connect([FromRoute] int roomId)
        {
            await _roomService.AddPlayer(roomId, User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "");
            return NoContent();
        }

        [Authorize]
        [HttpPost("{roomId}/createCharacter")]
        public async Task<IActionResult> CreateCharacter(
            [FromBody] CharacterCreateRequest characterCreateRequest,
            [FromRoute] int roomId)
        {
            await _roomService.CreatePlayerCharacter(characterCreateRequest,
                User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "",
                roomId);
            return Ok();
        }
    }
}
