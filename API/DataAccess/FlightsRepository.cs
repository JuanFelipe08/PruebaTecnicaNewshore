using API.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.DataAccess
{
    public class FlightsRepository: IFlightsRepository
    {
        static readonly HttpClient HttpClient = new HttpClient();

        private async Task<List<Flight>> GetFlightsData()
        {

            var Response = await HttpClient.GetAsync("https://recruiting-api.newshore.es/api/flights/2");
            Response.EnsureSuccessStatusCode();
            string responseBody = await Response.Content.ReadAsStringAsync();
            var ListFlights = JsonSerializer.Deserialize<List<Flight>>(
            responseBody, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true, WriteIndented = true });
            return ListFlights;

        }


        public List<Flight> GetFlights()
        {
            List<Flight> Flights = null;
            Flights = Task.Run(async () => await GetFlightsData()).GetAwaiter().GetResult();
            return Flights;
        }
    }
}
