
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Models.AmadeusResponse;

namespace API.Mappers
{
    public static class ResponseMapper
    {
        public static List<FlightResponse> AmadeusToResponse(AmadeusResponse amadeusResponse, string passengersNum)
        {
            var flightResponses = new List<FlightResponse>();

            foreach (var flight in amadeusResponse.Data)
            {
                var flightResponse = new FlightResponse
                {
                    DepartureNumOfStops = flight.Itineraries[0].Segments.Count.ToString(),
                    ReturnNumOfStops = flight.Itineraries[1].Segments.Count.ToString(),
                    TotalAmount = flight.Price.Total,
                    Currency = flight.Price.Currency,
                    Origin = flight.Itineraries[0].Segments[0].Departure.IataCode,
                    Destination = flight.Itineraries[1].Segments[0].Departure.IataCode,
                    DepartureDate = flight.Itineraries[0].Segments[0].Departure.At.ToString(),
                    ReturnDate = flight.Itineraries[1].Segments[0].Departure.At.ToString(),
                    NumOfPassengers = passengersNum,
                };

                flightResponses.Add(flightResponse);
            }

            return flightResponses;
        }
    }
}
