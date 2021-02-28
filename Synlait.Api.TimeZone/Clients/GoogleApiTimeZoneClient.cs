using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Synlait.Api.TimeZone.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Synlait.Api.TimeZone
{
    /// <summary>
    /// 
    /// </summary>
    public class GoogleApiTimeZoneClient : IGoogleApiTimeZoneClient
    {
        private readonly HttpClient _httpClient;
        public GoogleApiTimeZoneClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(configuration["Google:TimeZone:ApiUrl"]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="baseAddress"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public async Task<TimeZoneOutputModel> GetTimeZoneDataAsync(string apiKey, float latitude, float longitude, long time)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"/maps/api/timezone/json?location={latitude},{longitude}&timestamp={time}&key={apiKey}");
           
            var response = await _httpClient.SendAsync(httpRequestMessage);
            var responseData = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TimeZoneOutputModel>(responseData);
        }
    }
}
