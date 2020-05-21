using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Travel_Planner.Models;

namespace Travel_Planner.Services
{
    public class GeocodingService
    {
        public async Task<Geocoding> GetGeocodingWaypoints(Traveler traveler)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://maps.googleapis.com/maps/api/geocode/json?address={traveler.StreetAddress},+{traveler.City},+{traveler.State}&key={APIkeys.googleApi}");
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Geocoding>(json);
            }
            return null;
        }
    }
}
