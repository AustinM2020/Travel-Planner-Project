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
            string destinatiom;
            if (vacation.Destination.Contains(','))
            {
                destinatiom = vacation.Destination.Substring(0, vacation.Destination.IndexOf(','));
            }
            else
            {
                destinatiom = vacation.Destination;
            }
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-rapidapi-host", "tripadvisor1.p.rapidapi.com");
            client.DefaultRequestHeaders.Add("x-rapidapi-key", APIkeys.hotelApi);
            HttpResponseMessage response = await client.GetAsync($"https://tripadvisor1.p.rapidapi.com/locations/search?location_id=1&limit=30&sort=relevance&offset=0&lang=en_US&currency=USD&units=km&query={destinatiom}");
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<DestinationInfo>(json);
            }
            return null;
        }
    }
}
