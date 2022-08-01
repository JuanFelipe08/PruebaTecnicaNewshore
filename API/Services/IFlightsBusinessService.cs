using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    interface IFlightsBusinessService
    {
        Journey CheckIfThereAreFlightsAvailable(String Origin, String Destination, Journey journey);
    }
}
