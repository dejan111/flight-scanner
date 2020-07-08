using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class FlightRequest
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string DepartureDate { get; set; }
        public string ReturnDate { get; set; }
        public int PassengersNum { get; set; }
        public string Currency { get; set; }
    }
}
