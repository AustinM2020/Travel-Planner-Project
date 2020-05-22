using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Travel_Planner.Models;

namespace Travel_Planner.Services
{
    public class DestinationIdService
    {
        public async Task<DestinationInfo> GetDestinationId(Vacation vacation)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-rapidapi-host", "hotels4.p.rapidapi.com");
            client.DefaultRequestHeaders.Add("x-rapidapi-key", APIkeys.hotelApi);
            HttpResponseMessage response = await client.GetAsync($"https://hotels4.p.rapidapi.com/locations/search?locale=en_US&query={vacation.Destination.ToLower()}");
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<DestinationInfo>(json);
            }
            return null;
        }
    }
}
