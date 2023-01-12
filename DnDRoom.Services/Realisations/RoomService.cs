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
    public class RoomService : IRoomService
    {
        private readonly IUserService _userService;
        private readonly IRoomRepo _roomRepo;
        private readonly ICharacterService _characterService;
        public RoomService(
            IUserService userService,
            IRoomRepo roomRepo,
            ICharacterService characterService)
        {
            _userService = userService;
            _roomRepo = roomRepo;
            _characterService = characterService;
        }

        public async Task<Room> Create(RoomCreateRequest roomCreateRequest, string ownerId)
        {
            if (roomCreateRequest is null)
            {
                throw new Exception($"{nameof(roomCreateRequest)} can not be null");
            }
            if (string.IsNullOrEmpty(ownerId))
            {
                throw new Exception($"{nameof(ownerId)} can not be null or empty");
            }
            var owner = await _userService.GetById(ownerId);
            var newRoom = new Room()
            {
                Owner = owner,
                OwnerId = ownerId,
                Name = roomCreateRequest.roomName
            };
            await _roomRepo.Create(newRoom);
            return newRoom;
        }

        public async Task<Room?> GetById(int id)
        {
            return await _roomRepo.GetById(id);
        }

        public async Task Delete(int id)
        {
            Room? room = await _roomRepo.GetById(id);
            if (room is not null)
            {
                await _roomRepo.Delete(room);
            }
        }

        public async Task AddPlayer(int roomId, string playerId)
        {
            var room = await _roomRepo.GetById(roomId);
            var player = await _userService.GetById(playerId);

            if (room is null)
            {
                throw new Exception($"room with id {roomId} not found");
            }
            if (string.IsNullOrEmpty(playerId))
            {
                throw new Exception($"user with id {playerId} not found");
            }

            if (_roomRepo.GetPlayers(room).Any(x => x.Id == playerId))
            {
                throw new Exception($"user {playerId} already in room {roomId}");
            }

            await _roomRepo.AddPlayer(room, player);
        }

        public async Task CreatePlayerCharacter(CharacterCreateRequest characterCreateRequest, string playerId, int roomId)
        {
            var room = await _roomRepo.GetById(roomId);
            var player = await _userService.GetById(playerId);

            if (room is null)
            {
                throw new Exception($"room with id {roomId} not found");
            }
            if (string.IsNullOrEmpty(playerId))
            {
                throw new Exception($"user with id {playerId} not found");
            }

            if (playerId == room.OwnerId)
            {
                throw new Exception("room owner can not create player characters");
            }

            if (!_roomRepo.GetPlayers(room).Any(x => x.Id == playerId))
            {
                throw new Exception($"thare no user {playerId} in room {roomId}");
            }

            if (_roomRepo.GetPlayerCharacters(room).Any(x => x.OwnerId == playerId))
            {
                throw new Exception($"user {playerId} already have character in room {roomId}");
            }

            await _characterService.Create(characterCreateRequest, player, room);
        }
    }
}
