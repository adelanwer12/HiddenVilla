using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.IRepository;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using ModelsDtos;

namespace Business.Repository
{
    public class HotelRoomRepository: IHotelRoomRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HotelRoomRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<HotelRoomDto> CreateHotelRoom(HotelRoomDto hotelRoomDto)
        {
            var hotelRoom = _mapper.Map<HotelsRooms>(hotelRoomDto);
            hotelRoom.CreatedDate= DateTime.Now;
            hotelRoom.CreatedBy = "";
            var addedHotelRoom = await _context.HotelsRooms.AddAsync(hotelRoom);
            await _context.SaveChangesAsync();
            return _mapper.Map<HotelRoomDto>(addedHotelRoom.Entity);
        }

        public async Task<HotelRoomDto> UpdateHotelRoom(int roomId, HotelRoomDto hotelRoomDto)
        {
            if (roomId != hotelRoomDto.Id) return null;
            var roomFromRepo =await _context.HotelsRooms.FindAsync(roomId);
            var updateRoom = _mapper.Map(hotelRoomDto,roomFromRepo);
            updateRoom.UpdatedBy = "";
            updateRoom.UpdatedDate=DateTime.Now;
            _context.HotelsRooms.Update(updateRoom);
            await _context.SaveChangesAsync();
            return _mapper.Map<HotelRoomDto>(updateRoom);
        }

        public async Task<HotelRoomDto> GetHotelRoom(int roomId)
        {
            var hotelRoomFromRepo = await _context.HotelsRooms.FindAsync(roomId);
            return _mapper.Map<HotelRoomDto>(hotelRoomFromRepo);
        }

        public async Task<IEnumerable<HotelRoomDto>> GetAllHotelRoom()
        {
            var hotelsFromRepo = await _context.HotelsRooms.ToListAsync();
            return _mapper.Map<IEnumerable<HotelRoomDto>>(hotelsFromRepo);
        }

        public async Task<HotelRoomDto> IsRoomUnique(string name)
        {
            var hotelRoomFromRepo = await _context.HotelsRooms.FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
            return hotelRoomFromRepo == null ? null : _mapper.Map<HotelRoomDto>(hotelRoomFromRepo);
        }

        public async Task<int> DeleteHotelRoom(int roomId)
        {
            var hotelToDelete = await _context.HotelsRooms.FindAsync(roomId);
            if (hotelToDelete == null) return 0;
            _context.HotelsRooms.Remove(hotelToDelete);
            return await _context.SaveChangesAsync();
        }
    }
}
