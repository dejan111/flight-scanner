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
using API.Mappers;
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

        [HttpGet]
        [Route("flights")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new[] { "*" })]
        public async Task<IActionResult> GetFlights([FromQuery] FlightRequest flightRequest)
        {
            var flightSearch = RequestMapper.RequestToSearch(flightRequest);

            string requestUri = string.Format("/v2/shopping/flight-offers");
            string json = await Task.Run(() => JsonConvert.SerializeObject(flightSearch));

            var result = "";

            try
            {
                result = await _amadeusApiClient.PostProtectedResources(json, requestUri);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

            var amadeusResponse = JsonConvert.DeserializeObject<AmadeusResponse>(result);

            var response = ResponseMapper.AmadeusToResponse(amadeusResponse, flightRequest.PassengersNum.ToString());

            return Ok(response);
        }
    }
}