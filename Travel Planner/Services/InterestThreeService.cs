using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Travel_Planner.Models;

namespace Travel_Planner.Services
{
    public class InterestThreeService
    {
        public async Task<PlaceResults> GetInterestThreePlaces(Vacation vacation)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://maps.googleapis.com/maps/api/place/textsearch/json?query=parks+in+{vacation.Destination}&key={APIkeys.googleApi}");
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<PlaceResults>(json);
            }
            return null;
        }
    }
}
