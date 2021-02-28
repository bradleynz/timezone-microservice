using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Synlait.Api.TimeZone.Models
{
    public class TimeZoneOutputLogModel
    {
        public Guid RequestId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public long Timestamp { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
