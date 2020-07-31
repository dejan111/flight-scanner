using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.AmadeusResponse
{
    public class Itinerary
    {
        public Itinerary()
        {
            Segments = new List<Segment>();
        }

        public string Duration { get; set; }
        public List<Segment> Segments { get; set; }
    }
}
