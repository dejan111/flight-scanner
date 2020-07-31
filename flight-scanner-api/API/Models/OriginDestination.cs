using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class OriginDestination
    {
        public int id { get; set; }
        public string originLocationCode { get; set; }
        public string destinationLocationCode { get; set; }
        public DepartureDateTimeRange departureDateTimeRange { get; set; }
    }
}
