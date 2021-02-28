using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Synlait.Api.TimeZone.Models;
using Synlait.Api.TimeZone.Services;
using System;
using System.Threading.Tasks;

namespace Synlait.Api.Solution.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeZoneController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ITimeZoneService _timeZoneService;

        public TimeZoneController(IConfiguration configuration, ITimeZoneService timeZoneService)
        {
            _configuration = configuration;
            _timeZoneService = timeZoneService;
        }

        /// <summary>
        /// Get the request logs from the database
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("data/logs")]
        public IActionResult GetTimeZoneDataLogs()
        {
            return Ok(_timeZoneService.GetTimeZoneDataLogs());
        }

        /// <summary>
        /// Get a specific timezone data result from the third party service
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, Route("data")]
        public async Task<IActionResult> GetTimeZoneDataAsync(TimeZoneInputModel model)
        {
            var apiKey = _configuration["Google:TimeZone:ApiKey"];

            // Check to see if ApiKey defined in settings
            if(string.IsNullOrWhiteSpace(apiKey) || apiKey == "ADD API KEY HERE")
            {
                return BadRequest(new { Error = "Api Key not configured" });
            }
            return Ok(await _timeZoneService.GetTimeZoneDataAsync(apiKey, model.Latitude, model.Longitude, model.DateTimeOffset));
        }
    }
}
