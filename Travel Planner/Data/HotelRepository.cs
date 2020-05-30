using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel_Planner.Contracts;
using Travel_Planner.Models;

namespace Travel_Planner.Data
{
    public class HotelRepository : RepositoryBase<Hotel>, IHotelRepository
    {
        public HotelRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        public void CreateHotel(Hotel hotel)
        {
            Create(hotel);
        }

        public async void DeleteHotel(int hotelId)
        {
            var result = await FindByCondition(v => v.Id.Equals(hotelId));
            var hotel = result.SingleOrDefault();
            Delete(hotel);
        }

        public void EditHotel(Hotel hotel)
        {
            Update(hotel);
        }

        public async Task<Hotel> GetHotel(int hotelId)
        {
            var result = await FindByCondition(v => v.Id.Equals(hotelId));
            var hotel = result.SingleOrDefault();
            return hotel;
        }

        public async Task<List<Hotel>> GetHotels(int vacationId)
        {
            var results = await FindByCondition(v => v.VacationId.Equals(vacationId));
            var hotels = results.ToList();
            return hotels;
        }
    }
}
