using AutoMapper;
using DnDRoom.Contracts;
using DnDRoom.Models.ViewModels;

namespace DnDRoom.Mapping
{
    public static class MappingHelper
    {
        public static IMapper GetMapper()
        {
            MapperConfiguration configuration = new MapperConfiguration(config =>
            {
                config.CreateMap<Room, RoomViewModel>()
                    .ForMember(member => member.OwnerId, 
                        src => src.MapFrom(member => member.Owner.Id));
            });

            return configuration.CreateMapper();
        }
    }
}
