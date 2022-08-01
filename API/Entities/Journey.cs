using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Journey:JourneyAbstract
    {
        public List<Flight> Flights { get; set; }
    }
}
