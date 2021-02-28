using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Synlait.Api.TimeZone.Entities;
using Synlait.Api.TimeZone.Models;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Synlait.Api.TimeZone.Services
{
    /// <summary>
    /// Timezone service used to manage timezones
    /// </summary>
    public class TimeZoneService : BaseService, ITimeZoneService
    {
        private readonly IGoogleApiTimeZoneClient _googleApiTimeZoneClient;
        public TimeZoneService(IGoogleApiTimeZoneClient googleApiTimeZoneClient, IConfiguration configuration) : base(configuration)
        {
            _googleApiTimeZoneClient = googleApiTimeZoneClient;
        }

        /// <summary>
        /// Get the timzone data logs
        /// </summary>
        /// <returns></returns>
        public TimeZoneOutputLogModel[] GetTimeZoneDataLogs()
        {
            using(var database = new DatabaseContext(_options))
            {
                var query = (
                    from i in database.TimeZoneData
                    select new TimeZoneOutputLogModel
                    {
                        RequestId = i.RequestId,
                        Latitude = i.Latitude,
                        Longitude = i.Longitude,
                        Request = i.Request,
                        Response = i.Response,
                        Timestamp = i.Timestamp,
                        DateCreated = i.DateCreated,
                        DateModified = i.DateModified
                    }).ToArray();

                return query;
            }
        }
        /// <summary>
        /// Get the timezone data from the timezone API service
        /// </summary>
        /// <param name="apiKey">API Key</param>
        /// <param name="baseAddress">Base Address</param>
        /// <param name="latitude">Latitude</param>
        /// <param name="longitude">Longitude</param>
        /// <param name="dateTimeOffset">Timestamp</param>
        /// <returns>TimeZoneOutputModel</returns>
        public async Task<TimeZoneOutputModel> GetTimeZoneDataAsync(string apiKey, float latitude, float longitude, DateTimeOffset dateTimeOffset)
        {
            var data = await _googleApiTimeZoneClient.GetTimeZoneDataAsync(apiKey, latitude, longitude, dateTimeOffset.ToUnixTimeSeconds());

            using (var database = new DatabaseContext(_options))
            {
                var entity = new TimeZoneDataEntity
                {
                    RequestId = Guid.NewGuid(),
                    Latitude = latitude,
                    Longitude = longitude,
                    Request = JsonConvert.SerializeObject(new { latitude, longitude, timestamp = dateTimeOffset.ToUnixTimeSeconds(), apiKey }),
                    Response = JsonConvert.SerializeObject(data),
                    Timestamp = dateTimeOffset.ToUnixTimeSeconds(),
                    DateCreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow
                };

                database.TimeZoneData.Add(entity);
                await database.SaveChangesAsync();
            }

            return data;
        }
    }
}
