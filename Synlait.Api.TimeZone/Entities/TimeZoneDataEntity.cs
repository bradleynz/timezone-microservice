using System;
using System.ComponentModel.DataAnnotations;

namespace Synlait.Api.TimeZone.Entities
{
    public class TimeZoneDataEntity : BaseEntity
    {
        [Key]
        public Guid RequestId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public long Timestamp { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
    }
}
