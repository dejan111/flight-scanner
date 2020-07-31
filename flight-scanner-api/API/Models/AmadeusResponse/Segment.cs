using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.AmadeusResponse
{
    public class Segment
    {
        public FlightInfo Departure { get; set; }
        public FlightInfo Arrival { get; set; }
    }
}
