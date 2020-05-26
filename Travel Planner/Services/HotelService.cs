using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Travel_Planner.Models;

namespace Travel_Planner.Services
{
    public class HotelService
    {
        public async Task<HotelApi> GetHotels(Vacation vacation, Hotel hotel)
        {
            string checkIn = hotel.CheckIn.Value.ToString("yyyy-MM-dd");
            string checkOut = hotel.CheckOut.Value.ToString("yyyy-MM-dd");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-rapidapi-host", "hotels4.p.rapidapi.com");
            client.DefaultRequestHeaders.Add("x-rapidapi-key", APIkeys.hotelApi);
            HttpResponseMessage response = await client.GetAsync($"https://hotels4.p.rapidapi.com/properties/list?currency=USD&locale=en_US&sortOrder=PRICE&destinationId={vacation.DestinationId}&pageNumber=1&checkIn={checkIn}&checkOut={checkOut}&pageSize=25&adults1={hotel.NumberOfAdults}&children1={hotel.NumberOfChildren}");
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<HotelApi>(json);
            }
            return null;
        }
    }
}
