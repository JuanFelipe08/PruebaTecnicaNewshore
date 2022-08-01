using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public abstract class JourneyAbstract
    {
        public String Origin { get; set; }
        public String Destination { get; set; }
        public Double Price { get; set; }
    }
}
