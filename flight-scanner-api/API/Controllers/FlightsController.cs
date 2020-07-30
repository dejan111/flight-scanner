using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using API.ApiClient;
using API.Models;
using API.Models.AmadeusResponse;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IAmadeusApiClient _amadeusApiClient;

        public FlightsController(IAmadeusApiClient amadeusApiClient)
        {
            _amadeusApiClient = amadeusApiClient ?? throw new ArgumentNullException(nameof(amadeusApiClient));
        }

        [HttpPost]
        [Route("flightList")]
        public IActionResult GetFlights([FromBody] FlightRequest flightRequest)
        {
            return Ok("test");
        }

        [HttpPost]
        [Route("test")]
        public async Task<IActionResult> GetTest([FromBody] FlightRequest flightRequest)
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
                    originLocationCode = flightRequest.Origin,
                    destinationLocationCode = flightRequest.Destination,
                    departureDateTimeRange = new DepartureDateTimeRange
                    {
                        date = flightRequest.DepartureDate.Substring(0, 10)
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
                        date = flightRequest.ReturnDate.Substring(0, 10)
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
            }

            string requestUri = string.Format("/v2/shopping/flight-offers");
            string json = await Task.Run(() => JsonConvert.SerializeObject(flightSearch));

            var result = await _amadeusApiClient.PostProtectedResources(json, requestUri);

            var amadeusResponse = JsonConvert.DeserializeObject<AmadeusResponse>(result);

            return Ok(result);
        }
    }
}