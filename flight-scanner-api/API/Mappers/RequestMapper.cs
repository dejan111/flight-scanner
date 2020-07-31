using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Mappers
{
    public static class RequestMapper
    {
        public static FlightSearch RequestToSearch(FlightRequest flightRequest)
        {
            var flightSearch = new FlightSearch
            {
                currencyCode = flightRequest.Currency,
                sources = new string[] { "GDS" }
            };

            try
            {
                var originDestinations = new OriginDestination[2];
                var originDeparture = new OriginDestination
                {
                    id = 1,
                    originLocationCode = flightRequest.Origin.ToUpper(),
                    destinationLocationCode = flightRequest.Destination.ToUpper(),
                    departureDateTimeRange = new DepartureDateTimeRange
                    {
                        date = Convert.ToDateTime(flightRequest.DepartureDate).ToString("yyyy-MM-dd")
                    }
                };

                originDestinations[0] = originDeparture;

                var destinationDeparture = new OriginDestination
                {
                    id = 2,
                    originLocationCode = flightRequest.Destination,
                    destinationLocationCode = flightRequest.Origin,
                    departureDateTimeRange = new DepartureDateTimeRange
                    {
                        date = Convert.ToDateTime(flightRequest.ReturnDate).ToString("yyyy-MM-dd")
                    }
                };

                originDestinations[1] = destinationDeparture;

                var travelers = new Traveler[Convert.ToInt32(flightRequest.PassengersNum)];

                for (int i = 0; i < Convert.ToInt32(flightRequest.PassengersNum); i++)
                {
                    var traveler = new Traveler
                    {
                        id = (i + 1).ToString(),
                        travelerType = "ADULT"
                    };

                    travelers[i] = traveler;
                };

                flightSearch.originDestinations = originDestinations;
                flightSearch.travelers = travelers;
            }
            catch (Exception ex)
            {
                //Model is not ok
            }

            return flightSearch;
        }
    }
}
