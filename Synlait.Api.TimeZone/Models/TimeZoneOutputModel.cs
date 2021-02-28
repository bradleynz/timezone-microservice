using Newtonsoft.Json;

namespace Synlait.Api.TimeZone.Models
{
    public class TimeZoneOutputModel
    {
        [JsonProperty("dstOffset")]
        public int DstOffset { get; set; }

        [JsonProperty("rawOffset")]
        public int RawOffset { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("timeZoneId")]
        public string TimeZoneId { get; set; }

        [JsonProperty("timeZoneName")]
        public string TimeZoneName { get; set; }
    }
}
