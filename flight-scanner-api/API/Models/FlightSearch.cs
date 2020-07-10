using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class FlightSearch
    {
        public string CurrencyCode { get; set; }
        public OriginDestination[] OriginDestinations { get; set; }
        public Traveler[] Travelers { get; set; }
        public string[] Sources { get; set; }
    }
}
