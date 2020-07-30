using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.AmadeusResponse
{
    public class Data
    {
        public Data()
        {
            Itineraries = new HashSet<Itinerary>();
        }

        public string Id { get; set; }
        public bool OneWay { get; set; }
        public int NumberOfBookableSeats { get; set; }
        public IEnumerable<Itinerary> Itineraries { get; set; }
        public Price Price { get; set; }
    }
}
