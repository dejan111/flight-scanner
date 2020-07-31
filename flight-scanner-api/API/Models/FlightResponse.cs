using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class FlightResponse
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string DepartureDate { get; set; }
        public string ReturnDate { get; set; }
        public string DepartureNumOfStops { get; set; }
        public string ReturnNumOfStops { get; set; }
        public string NumOfPassengers { get; set; }
        public string Currency { get; set; }
        public string TotalAmount { get; set; }
    }
}
