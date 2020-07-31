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
            Itineraries = new List<Itinerary>();
        }

        public string Id { get; set; }
        public bool OneWay { get; set; }
        public int NumberOfBookableSeats { get; set; }
        public List<Itinerary> Itineraries { get; set; }
        public Price Price { get; set; }
    }
}
