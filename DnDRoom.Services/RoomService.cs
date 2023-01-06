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
    public class RoomService : IRoomService
    {
        private readonly IUserService _userService;

        private readonly IRoomRepo _roomRepo;

        public RoomService(
            IUserService userService, 
            IRoomRepo roomRepo)
        {
            _userService = userService;
            _roomRepo = roomRepo;
        }

        public async Task<Room> create(RoomCreateRequest roomCreateRequest, string ownerId)
        {
            var owner = await _userService.GetById(ownerId);
            var newRoom = new Room()
            {
                Owner = owner,
                OwnerId = ownerId,
                Name = roomCreateRequest.roomName
            };
            await _roomRepo.Add(newRoom);
            return newRoom;
        }
    }
}
