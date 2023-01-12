using DnDRoom.Contracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDRoom.Models.ViewModels
{
    public class RoomViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string OwnerId { get; set; }

        //public RoomViewModel(Room room, User owner)
        //{
        //    Id = room.Id;
        //    Name = room.Name;
        //}
    }
}
