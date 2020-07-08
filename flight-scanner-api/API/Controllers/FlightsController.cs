using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        public FlightsController()
        { }

        [HttpGet]
        [Route("flightList")]
        public IActionResult GetFlights([FromBody] FlightRequest flightRequest)
        {
            return Ok("test");
        }
    }
}