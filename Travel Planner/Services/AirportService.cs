using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Travel_Planner.Models;

namespace Travel_Planner.Services
{
    public class AirportService
    {
        public async Task<AirportApi> GetAirports(string destination)
        {
            string[] words = destination.Split(',');
            string place;
            if (words.Length <= 1)
            {
                place = destination;
            }
            else
            {
                place = words[1].Trim();
            }
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("APC-Auth", APIkeys.apcauth);
            client.DefaultRequestHeaders.Add("APC-Auth-Secret", APIkeys.apcsecret);
            HttpResponseMessage response = await client.GetAsync($"https://www.air-port-codes.com/api/v1/autocomplete?term={place}");
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<AirportApi>(json);
            }
            return null;
        }
    }
}
