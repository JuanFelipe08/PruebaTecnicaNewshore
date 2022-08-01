using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Flight:JourneyAbstract
    {
        [JsonPropertyName("DepartureStation")]
        public new String Origin { get; set; }

        [JsonPropertyName("arrivalStation")]
        public new String Destination { get; set; }


        [JsonPropertyName("flightCarrier")]
        public String FlightCarrier { get; set; }

        [JsonPropertyName("flightNumber")]
        public String FlightNumber { get; set; }
    }
}
