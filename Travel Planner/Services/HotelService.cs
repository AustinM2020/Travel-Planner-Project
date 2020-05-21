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
        public async Task<HotelApi> GetHotels(Vacation vacation)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-rapidapi-host", "hotels4.p.rapidapi.com");
            client.DefaultRequestHeaders.Add("x-rapidapi-key", APIkeys.hotelApi);
            HttpResponseMessage response = await client.GetAsync($"https://hotels4.p.rapidapi.com/properties/list?currency=USD&locale=en_US&sortOrder=PRICE&destinationId=1506246&pageNumber=1&checkIn=2020-01-08&checkOut=2020-01-15&pageSize=25&adults1=1");
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<HotelApi>(json);
            }
            return null;
        }
    }
}
