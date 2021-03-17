using AutoMapper;
using Models;
using ModelsDtos;

namespace Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<HotelRoomDto, HotelsRooms>().ReverseMap();
        }
    }
}
