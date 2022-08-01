using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JourneyController : ControllerBase
    {
        //FlightsBusiness FlightsBusiness = null;
        private readonly IFlightsBusinessService flightsBusinessService;
        private readonly ILogger<JourneyController> _logger;
        private readonly IConfiguration configuration;
        
        public JourneyController(ILogger<JourneyController> logger, IFlightsBusinessService flightsBusiness, IConfiguration configuration)
        {
            _logger = logger;
            flightsBusinessService = flightsBusiness;
            this.configuration = configuration;
        }

        // GET api/Journey/PEI/BOG
        [HttpGet("{Origin}/{Destination}")]


        public Object Get([FromHeader]String Authorization, String Origin, String Destination)
        {
            if (!isAuthenticate(Authorization))
            {
                return new String("el token no concuerda ");
            }
            Journey journey = new Journey();
            _logger.LogInformation($"trips were sought for the following cities:   origin: {Origin}, destination: {Destination}");
            journey = flightsBusinessService.CheckIfThereAreFlightsAvailable(Origin, Destination, journey);
            if (journey.Origin == null)
            {

                _logger.LogWarning($"no trips were found for the following cities:   origin: {Origin}, destination: {Destination} ");
                String response = new String("la consulta no puede ser procesada");
                return response;
            }

            return journey;
        }

        private bool isAuthenticate(String AccessToken)
        {
            string secret = configuration["secret"].ToString();

            if (AccessToken != secret)
            {
                _logger.LogInformation(AccessToken);
                _logger.LogInformation(secret);
                return false;
            }
            return true;
        }
    }
}