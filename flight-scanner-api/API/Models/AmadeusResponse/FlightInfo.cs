using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.AmadeusResponse
{
    public class FlightInfo
    {
        public string IataCode { get; set; }
        public string Terminal { get; set; }
        public DateTime At { get; set; }
    }
}
