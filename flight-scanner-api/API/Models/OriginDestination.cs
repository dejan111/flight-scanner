using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class OriginDestination
    {
        public int Id { get; set; }
        public string OriginLocationCode { get; set; }
        public string DestinationLocationCode { get; set; }
        public DepartureDateTimeRange DepartureDateTimeRange { get; set; }
    }
}
