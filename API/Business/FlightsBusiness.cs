using API.DataAccess;
using API.Entities;
using API.Services;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Business
{
    public class FlightsBusiness: IFlightsBusinessService
    {
        private readonly IMemoryCache _memoryCache;
        private IFlightsRepository flightsRepository;

        public FlightsBusiness(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            flightsRepository = new FlightsRepository();
        }


        public Journey CheckIfThereAreFlightsAvailable(String Origin, String Destination, Journey journey)
        {
            journey.Flights = new List<Flight>();
            List<Flight> ListFlights = null;
            ListFlights = GetFlights();

            foreach (var flight in ListFlights)
            {

                if (flight.Origin.Equals(Origin) && flight.Destination.Equals(Destination))
                {
                    journey.Origin = flight.Origin;
                    journey.Destination = flight.Destination;


                    journey.Flights.Insert(0, flight);
                    journey.Price += flight.Price;
                }
                else if (flight.Origin.Equals(Destination) && flight.Destination.Equals(Origin))
                {
                    journey.Flights.Add(flight);
                    journey.Price += flight.Price;
                }
            }

            return journey;
        }

        private List<Flight> GetFlights()
        {

            _memoryCache.Set("ListFlights", flightsRepository.GetFlights());

            return _memoryCache.GetOrCreate("ListFlights",
                cacheListFlight =>
                {
                    return flightsRepository.GetFlights();
                });
        }
    }
}
