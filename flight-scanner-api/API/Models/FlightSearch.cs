using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class FlightSearch
    {
        public string currencyCode { get; set; }
        public OriginDestination[] originDestinations { get; set; }
        public Traveler[] travelers { get; set; }
        public string[] sources { get; set; }
    }
}
