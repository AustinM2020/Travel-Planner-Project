using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel_Planner.Models;

namespace Travel_Planner.Contracts
{
    public interface IHotelRepository : IRepositoryBase<Hotel>
    {
        Task<List<Hotel>> GetHotels(int vacationId);
        Task<Hotel> GetHotel(int hotelId);
        void CreateHotel(Hotel hotel);
        void EditHotel(Hotel hotel);
        void DeleteHotel(int hotelId);
    }
}
