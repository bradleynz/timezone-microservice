using Newtonsoft.Json;
using System;

namespace Synlait.Api.TimeZone.Models
{
    public class TimeZoneInputModel
    {
        [JsonProperty("latitude")]
        public float Latitude { get; set; }

        [JsonProperty("latitude")]
        public float Longitude { get; set; }

        [JsonProperty("dateTimeOffset")]
        public DateTimeOffset DateTimeOffset { get; set; }
    }
}
