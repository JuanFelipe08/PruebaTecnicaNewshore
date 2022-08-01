using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DataAccess
{
    interface IFlightsRepository
    {
        List<Flight> GetFlights();
    }
}
